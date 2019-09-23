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
    /* public変数*/
    //public bool onLeft;      //左の縁に着地した瞬間
    //public bool onRight;     //右の縁に着地した瞬間 
    public bool landing;     //縁に着地した瞬間

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
            roll.z += playerManager.speed * MyJoyCon.joyconDec.accel.y;
            //roll.z += playerManager.speed * DebugMode();
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
