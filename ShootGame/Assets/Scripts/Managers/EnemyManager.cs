using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;    //只有玩家的血量还有的时候，才继续生成敌人
    public GameObject enemy;             //生成敌人的游戏对象应用
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);   //在调用Spawn这个函数时之前，先等spawnTime的时间，在重复的执行之前要等spawnTime的时间
                                                           //这里是每三秒检测一次，调用一次Spawn函数
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)    //检测玩家是否还有生命值
        {
            return;                             //如果死了，就return
        }

        int spawnPointIndex = Random.Range (0,spawnPoints.Length);  //如果还没死，那就生成敌人  随机生成

                  //生成什么  在哪生成                             以及生成时旋转角度
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        //                  -----------------------------------------------------------------------------
        //                          这两个参数就是Transform中的position 以及 rotation
    }
}
