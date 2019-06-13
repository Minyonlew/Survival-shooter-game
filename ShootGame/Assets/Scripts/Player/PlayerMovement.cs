using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;                       //存储移动信息并应用在玩家身上
    Animator anim;                          //Animator组件的引用
    Rigidbody playerRigidbody;              //Rigidbody 组件的引用
    int floorMask;                          //让Raycast 照射的平面（让他只照射在floor上）
    float camRayLength = 100f;                     //从相机发射出的射线的长度

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");    //将Floor 平面放进Floor Layer，然后通过Floor 获取Mask
        anim = GetComponent<Animator>();             //获取Animatot 组件的引用
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()    //每次物理更新时（固定时间间隔）会被Unity自动调用
    {
        float h = Input.GetAxisRaw("Horizontal");  //按 A D 键 左右平移 
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);

    }
    //建立一个Move方法在FixedUpdate 中调用，来移动角色
    void Move(float h , float v)
    {
        movement.Set(h, 0f, v); //获取水平面的方法移动 （垂直方向不用设置）
        movement = movement.normalized * speed * Time.deltaTime;  //保证玩家在每个方向上的移动速度都一样
        playerRigidbody.MovePosition(transform.position + movement);   //玩家的位置加上我们希望他移动的距离
    }

    void Turning()  //玩家的转向  这是由鼠标决定的
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //创建一个射线，从相机射向场景，这一点是鼠标指向的方向
        RaycastHit floorHit;
        //射出射线,out是指要用到外部的信息来给floorHit，射线的长度，确保射到floor上
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))     
        {
            //如果射中了
            Vector3 playerToMouse = floorHit.point - transform.position;   //从角色位置(transform.position)指向鼠标击中的点    
            playerToMouse.y = 0f;                                          //不希望它绊倒 把Y轴设定

            Quaternion newRotation =  Quaternion.LookRotation(playerToMouse);  //将鼠标方向设定为人物面向的方向
            playerRigidbody.MoveRotation(newRotation);
        }
        
    }

    void Animating (float h, float v)
    {
        bool walking = h != 0f || v != 0f;   //判断人物是否在走动
        anim.SetBool("IsWalking", walking);
    }
}

