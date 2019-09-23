using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlControl : MonoBehaviour
{
    struct PlayerParameter
    {
       public float speed;
    }
    PlayerParameter plParam = new PlayerParameter();


    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        
        Parameter(Time.deltaTime);

        
        var plPos = transform.position;
        plPos.x += MyJoyCon.joyconDec.accel.y * plParam.speed * (-1);
        transform.position = plPos;




        Debug.Log(MyJoyCon.joyconDec.accel);
    }

    void Parameter(float timer)
    {
        plParam.speed = speed * timer;
    }

}
