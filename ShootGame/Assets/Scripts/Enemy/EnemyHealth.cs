using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;    //敌人挂掉后 沉入地下然后消失
    public int scoreValue = 10;       //杀掉敌人之后加的分数
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;            //粒子系统
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;                     //是否沉下


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)           //是否应该沉下
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);  //下沉方式及其下沉时间
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)     //承受伤害
    {
        if(isDead)
            return;

        enemyAudio.Play ();             //受伤时的动作

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;    
        hitParticles.Play();                //粒子系统效果播放

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;     //敌人死掉之后应该不被当作障碍物

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;   //不要禁用整个游戏对象，只禁止一个组件
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);   //两秒之后，销毁这个敌人对象
    }
}
