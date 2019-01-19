using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    //Camera 水平移动速度
    float speedH = 20f;
    //Camera 垂直移动速度
    public float speedV = 40f;
    //x方向最小值
    float minX = -67f;
    //x方向最大值
    float maxX = 70f;
    //y方向最小值
    float minY = -75f;
    //y方向最大值
    float maxY = 50f;
    //插值速度
    float lerpSpeed = 4f;

    //位置插值目标 
    private Vector3 posTarget;
    //屏幕的宽度
    private float screenWidth;
    //屏幕的高度
    private float screenHeight;

    bool AddSpeed;

    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        posTarget = transform.position;
        AddSpeed = false;
        speedH *= 2;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            transform.localEulerAngles += new Vector3(0, x, 0);
            transform.localEulerAngles += new Vector3(-y, 0, 0);
            //if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            //{ AddSpeed = true; }
            //else
            //{ AddSpeed = false; }

            //if (AddSpeed)
            //{
            //    speedV = speedH;
            //}
            //else
            //{
            //    speedV = 20;
            //}

            if (Input.GetKey(KeyCode.E))
            {
                posTarget = posTarget + transform.up * speedV * 0.002f;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                posTarget = posTarget + transform.up * -speedV * 0.002f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                posTarget = posTarget + transform.forward * speedV * 0.002f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                posTarget = posTarget + transform.forward * -speedV * 0.002f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                posTarget = posTarget + transform.right * -speedV * 0.002f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                posTarget = posTarget + transform.right * speedV * 0.002f;
            }

        }


    }
    void LateUpdate()
    {
        if (Vector3.Distance(posTarget, transform.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, posTarget, Time.deltaTime * lerpSpeed);
        }
        else
        {
            transform.position = posTarget;
        }
    }

}
