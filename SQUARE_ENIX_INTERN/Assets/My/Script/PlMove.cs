using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlMove : MonoBehaviour
{
    public float speed = 10;

    struct PlayerParameter
    {
        public float speed;
    }
    PlayerParameter plParam = new PlayerParameter();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var roll = transform.rotation.eulerAngles;

        //回転
        if (roll.z < 90 && roll.z > -90)
        {
            roll.z += speed * MyJoyCon.joyconDec.accel.y;
            transform.rotation = Quaternion.Euler(roll);
        }
        if(roll.z > 90)
        {
            Debug.Log("aaa");
        }
        if(roll.z < -90)
        {
            Debug.Log("bbb");
        }


    }

    void Parameter(float timer)
    {
        plParam.speed = speed * timer;
    }   
}
