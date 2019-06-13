using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;             //玩家当前血量
    public Slider healthSlider;           //
    public Image damageImage;
    public AudioClip deathClip;           //死掉的时候的声音
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);   //受到攻击时屏幕闪烁  红色 不透明是十分之一


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;         //之前写过的脚本
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;                           //玩家是否受伤


    void Awake ()                      //游戏刚开始
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else  
        {                       //展示红色的图片  (受伤时)
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;        //展示图片只有一瞬间
    }


    public void TakeDamage (int amount)      //当敌人攻击玩家调用这个方法
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)    //判断玩家是否要挂掉
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
