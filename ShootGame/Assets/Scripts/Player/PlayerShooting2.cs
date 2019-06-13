using UnityEngine;

public class PlayerShooting2 : MonoBehaviour
{
    
    //手榴弹
    public int damagePerShot = 40;                  //每抢40伤害
    public float timeBetweenBullets = 0.30f;        //射击速度
    public float range = 50f;                      //能射击多远



    float timer;                                    //确保只有时间满足才能射击
    Ray shootRay = new Ray();
    RaycastHit shootHit;                            //返回射中的东西
    int shootableMask;                              //只能击中可射击的东西
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;                //射击效果可持续的时间   0.2f


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");   //设计 "Shootable" Mask的对象为可射击对象
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire2") && timer >= timeBetweenBullets && Time.timeScale != 0)//如果玩家点击鼠标右键且射击的时间运行(上一次的射击后摇结束)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)//开火后摇没结束时
        {
            DisableEffects();
        }
    }


    public void DisableEffects()  //开火后摇没结束时 关闭火焰和亮光
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);    //打开射击效果

        shootRay.origin = transform.position;    //子弹只能在枪头射出
        shootRay.direction = transform.forward;  //子弹沿枪头方向射出

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))       //判断射击的东西
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)                                             //判断是否为障碍物
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);                //击中物体后让子弹停留在物体上
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
