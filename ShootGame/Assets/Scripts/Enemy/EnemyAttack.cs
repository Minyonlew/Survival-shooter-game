using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;   //攻击时间为0.5秒
    public int attackDamage = 10;             //攻击伤害


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;                       //只有玩家在敌人的这个范围内才可以为true
    float timer;                              //确保敌人不会太快或太慢


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)   //Trigger(触发器)来了   参数other 敌人碰撞到的物体
    {
        if(other.gameObject == player)    //判断碰到的物体是否为玩家
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)    //Trigger(触发器)离开了
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)  //如果在攻击时间内（可以理解为攻击前摇或后摇）、玩家在攻击范围且敌人还没死掉，就开始攻击
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)      //如果玩家挂掉，那就停止（调用“PlayerDead”）
        {
            anim.SetTrigger ("PlayerDead");      //将敌人的动画从move调到idle（玩家挂掉，敌人停止移动）
        }
    }


    void Attack ()
    {
        timer = 0f;         //重置攻击前摇

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
