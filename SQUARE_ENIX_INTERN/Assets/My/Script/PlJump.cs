﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlJump : MonoBehaviour
{
    bool isJumpEnd;
    Vector3 startPos;
    Vector3 tmpPos;
    PlMove.PlayerParameter plParam;

    SoumenStatus status;
    SoumenShot shot;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        shot = GetComponent<SoumenShot>();
        status = GetComponent<SoumenStatus>();
    }

    // Update is called once per frame
    void Update()
    {


        plParam = PlMove.plParam;
        var pos = transform.position;

        if (plParam.isJump)
        {
            if (!isJumpEnd)
            {
                pos = Vector3.Lerp(pos, new Vector3(tmpPos.x, tmpPos.y + plParam.high, tmpPos.z), Time.deltaTime * plParam.jumpPower);
            }
            else
            {
                pos = Vector3.Lerp(pos, tmpPos, Time.deltaTime * plParam.jumpPower);
            }

            if (pos.y > tmpPos.y + plParam.high - 0.1f)
            {
                isJumpEnd = true;
            }
        }
        else
        {
            tmpPos = transform.position;
        }


        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "JumpObj")
        {
            
            if (plParam.isJump)
            {
                transform.localPosition = startPos;

                isJumpEnd = false;
                plParam.isJump = false;
                Time.timeScale = 1f;
            }
            else
            {
                plParam.isJump = true;

                shot.SearchHuman();
                SoumenShot.jumpTrigger = true;
                Debug.Log("Jump!");
                Time.timeScale = 0.2f;
            }
            PlMove.plParam.isJump = plParam.isJump;
        }
    }
}
