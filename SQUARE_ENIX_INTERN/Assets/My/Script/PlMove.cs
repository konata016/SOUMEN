using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlMove : MonoBehaviour
{
    public float speed = 20;
    public float high = 3;
    public float jumpPower = 5;

    public struct PlayerParameter
    {
        public float speed;
        public bool isJump;
        public float high;
        public float jumpPower;
    }
    public static PlayerParameter plParam = new PlayerParameter();

    // Start is called before the first frame update
    void Start()
    {
        plParam.high = high;
        plParam.jumpPower = jumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        Parameter(Time.deltaTime);

        var roll = transform.rotation.eulerAngles;
        Debug.Log(roll.z);

        //回転
        if (!plParam.isJump)
        {
            //roll.z += speed * MyJoyCon.joyconDec.accel.y;
            roll.z += plParam.speed * DebugMode();
        }
        

        transform.rotation = Quaternion.Euler(roll);
    }

    void Parameter(float timer)
    {
        plParam.speed = speed * timer;

    }

    float DebugMode()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return -speed / 2;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return speed / 2;
        }
        return 0;
    }
}
