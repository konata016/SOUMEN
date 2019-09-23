using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの着地の処理。プレイヤーの回転の軸にアタッチする。
/// </summary>
public class JumpBlock : MonoBehaviour
{

    /* public変数*/
    public bool onLeftBlock;      //左の縁に着地した瞬間
    public bool onRightBlock;     //右の縁に着地した瞬間

    /* --- SerializeFieldの変数 --- */
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject CameraObj;

    /* --- 変数 ---*/

    /* --- private変数 --- */
    private CameraFollow cameraFollow;

    private float slide = 3;        //着地後に自動的に元の位置に戻すスピード
    private bool exitFlag = true;


    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        cameraFollow = CameraObj.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの回転移動の軸
        var axisRotate = transform.rotation.eulerAngles;

        if (playerController.isJump)
        {
            if (onLeftBlock || onRightBlock)
            {

                //0.01秒間操作を受け付けず、中央に向かって自動的に移動する
                if (!exitFlag)
                {
                    //左の縁に着地した時
                    if (onLeftBlock)
                    {
                        axisRotate.z += slide * Time.deltaTime;
                    }
                    //右の縁に着地した時
                    else
                    {
                        axisRotate.z -= slide * Time.deltaTime;
                    }
                }
                else
                {
                    onLeftBlock = false;
                    onRightBlock = false;
                    playerController.isJump = false;
                    exitFlag = false;

                    SoundFlagManager.isLand = true;

                    cameraFollow.setDefaultRotate();
                }
            }
        }

        transform.rotation = Quaternion.Euler(axisRotate);
    }
}
