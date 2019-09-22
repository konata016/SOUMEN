using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlMove : MonoBehaviour
{
    public float speed = 20;
    public float high = 100;

    public struct PlayerParameter
    {
        public float speed;
        public bool isJump;
        public float high;
    }
    public static PlayerParameter plParam = new PlayerParameter();

    // Start is called before the first frame update
    void Start()
    {
        plParam.high = high;
    }

    // Update is called once per frame
    void Update()
    {
        Parameter(Time.deltaTime);

        var roll = transform.rotation.eulerAngles;
        Debug.Log(roll.z);

        //回転
        if (roll.z < 90 || roll.z > 270)
        {
            //roll.z += speed * MyJoyCon.joyconDec.accel.y;
            roll.z += plParam.speed * DebugMode();
        }
        else
        {
            plParam.isJump = true;
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
