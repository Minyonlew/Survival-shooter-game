using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   //追踪目标
    public float smoothing = 5f; //是画面有延时，变得跟顺滑一点

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position; //transform.position(相机)减去角色 = 相机到角色的向量
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        //得到当前坐标和目的地坐标，逐渐移动到目的地
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

    }

}
