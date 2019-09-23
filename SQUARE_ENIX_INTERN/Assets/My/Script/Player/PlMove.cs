using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

/// <summary>
/// プレイヤーの横移動の処理。プレイヤーの回転の軸にアタッチする。
/// </summary>
public class PlMove : MonoBehaviour
{
    /* 定数 */
    private const float unableControlTime = 1f;   //着時した時に操作が制限される時間

    /* public変数*/
    public bool landing;     //縁に着地した瞬間
    public bool isLandLeft = false;    //着地後に反対側に操作ができない
    public bool isLandRight = false;    //着地後に反対側に操作ができない

    /* --- SerializeFieldの変数 --- */
    [SerializeField] GameObject playerManageObj;
    [SerializeField] GameObject player;

    [SerializeField] float slide;       //淵に着地した時に内側に滑り込ませる量
    //[SerializeField] float unableTime;    //淵に着地した時に操作を受け付けない時間

    /* --- 変数 ---*/

    /* --- private変数 --- */
    private PlayerController playerController;
    private PlayerManager playerManager;
    private float jumpCoolCount;

    private float landWaitTime;          //着時後経過した時間

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerManager = playerManageObj.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var roll = transform.rotation.eulerAngles;

        //回転
        if (!playerController.isJump)
        {
            if (isLandLeft)
            {
                if (landWaitTime < unableControlTime)
                {
                    roll.z += Mathf.Clamp(playerManager.speed * MyJoyCon.joyconDec.accel.y, 10, 180);
                }
                else
                {
                    isLandLeft = false;
                    landWaitTime = 0;
                }
            }
            else if (isLandRight)
            {
                if (landWaitTime < unableControlTime)
                {
                    roll.z += Mathf.Clamp(playerManager.speed * MyJoyCon.joyconDec.accel.y, -180, -10);
                }
                else
                {

                    isLandRight = false;
                    landWaitTime = 0;
                }
            }
            else
            {
                roll.z += playerManager.speed * MyJoyCon.joyconDec.accel.y;
            }
        }
        
        transform.rotation = Quaternion.Euler(roll);
    }

    /// <summary>
    /// デバッグ用の矢印キーでの移動。
    /// </summary>
    /// <returns></returns>
    float DebugMode()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return playerManager.speed / 2;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return -playerManager.speed / 2;
        }
        return 0;
    }
}
