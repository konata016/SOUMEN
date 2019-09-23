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

    PlayerManager plManag;

    // Start is called before the first frame update
    void Start()
    {
        plManag = GetComponent<PlayerManager>();

        //初期値セット用
        normalSpeed = plManag.speed;
        normalJumpHigh = plManag.dashJump;
        dashSpeed = plManag.dashSpeed;
        dashJumpHigh = plManag.dashSpeed;
        onDashTrigger = false;

        //
        plSpeed = normalSpeed;
        plJumpHigh = normalJumpHigh;

    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.1f * Time.deltaTime;

        //joyCon入力時
        if (MyJoyCon.joyconDec.button == Joycon.Button.SHOULDER_2)
        {
            Debug.Log("change speed");
            onDashTrigger = true;
        }

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

        plManag.speed = plSpeed;
        plManag.jumpHeight = plJumpHigh;
    }

}