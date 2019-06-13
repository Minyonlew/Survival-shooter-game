using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    Text text;


    void Awake ()      //初始化
    {
        text = GetComponent <Text> ();   //获取Text 组件
        score = 0;                       
    }


    void Update ()          //更新的是分数
    {
        text.text = "Score: " + score;
    }
}
