using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlDash : MonoBehaviour
{
    float plSpeed;
    float plJumpHigh;
    bool onDashTrigger;

    //初期値定義用
    float normalSpeed;
    float normalJumpHigh;
    float dashSpeed;
    float dashJumpHigh;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //初期値セット用
        normalSpeed = 3;
        normalJumpHigh = 1;
        dashSpeed = 5;
        dashJumpHigh = 3;
        onDashTrigger = true;

        //
        plSpeed = normalSpeed;
        plJumpHigh = normalJumpHigh;

    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.1f * Time.deltaTime;

        //ダッシュした場合速度を変える
        if (onDashTrigger)
        {
            plSpeed = dashSpeed;
            plJumpHigh = dashJumpHigh;
        }
        else
        {
            timer = 0;
        }

        //一定時間たったらダッシュ状態を解除する
        if (timer > 0.05f)
        {
            plSpeed = normalSpeed;
            plJumpHigh = normalSpeed;
            onDashTrigger = false;
        }
    }

    //受け渡し用
    public float JumpHigh()
    {
        return plJumpHigh;
    }
    public float Speed()
    {
        return plSpeed;
    }
}