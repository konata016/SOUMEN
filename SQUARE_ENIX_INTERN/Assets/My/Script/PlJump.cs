using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlJump : MonoBehaviour
{
    bool isJumpEnd;
    Vector3 startPos;
    Vector3 tmpPos;
    PlMove.PlayerParameter plParam;

    // Start is called before the first frame update
    void Start()
    {
        //スタートの座標を記録
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //変数名を短くするやつ
        plParam = PlMove.plParam;

        var pos = transform.position;

        if (plParam.isJump)
        {
            
            if (!isJumpEnd)
            {
                //ジャンプした場合
                pos = Vector3.Lerp(pos, new Vector3(tmpPos.x, tmpPos.y + plParam.high, tmpPos.z), Time.deltaTime * plParam.jumpPower);
            }
            else
            {
                //落下
                pos = Vector3.Lerp(pos, tmpPos, Time.deltaTime * plParam.jumpPower);
            }

            //最高高度に達した場合ジャンプする処理を止める
            if (pos.y > tmpPos.y + plParam.high - 0.1f)
            {
                isJumpEnd = true;
            }
        }
        else
        {
            //初めにジャンプした位置を記録
            tmpPos = transform.position;
        }

        //
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        //ジャンプの判定
        if (other.gameObject.tag == "JumpObj")
        {
            
            if (plParam.isJump)
            {
                //着地した時の処理
                transform.localPosition = startPos;

                isJumpEnd = false;

                JumpBloc.landing = true;

                plParam.isJump = false;
            }
            else
            {
                //ジャンプオブジェクトに触れたときにジャンプするフラグを立てる
                plParam.isJump = true;

            }

            PlMove.plParam.isJump = plParam.isJump;
        }

        if (other.gameObject.name == "RightJumpObj")
        {
            JumpBloc.onRight = true;
        }
        if (other.gameObject.name == "LeftJumpObj")
        {
            JumpBloc.onLeft = true;
        }
    }
}
