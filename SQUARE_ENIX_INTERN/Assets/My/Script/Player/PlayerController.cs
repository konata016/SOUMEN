using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動と着地以外のプレイヤーの処理
/// </summary>
public class PlayerController : MonoBehaviour
{
    /* public変数*/
    public bool isJump = false;             //ジャンプ中華
    public bool isJumpDown = false;         //ジャンプ時に上昇しているか落下しているか

    /* --- SerializeFieldの変数 --- */
    [SerializeField] Camera camera;
    [SerializeField] GameObject playerManageObj;
    [SerializeField] GameObject playerRotateAxis;
    [SerializeField] GameObject attackSoumen;
    [SerializeField] private float triggerValue;        //そうめんを撃つ角度変化のボーダー
    [SerializeField] private float shotCoolDown;        //そうめんを撃つ判定のクールダウンの設定値

    /* --- 変数 ---*/

    /* --- private変数 --- */
    private PlayerManager playerManager;    //プレイヤーのステータスなどを管理するスクリプト
    private JumpBlock jumpBlock;            //着地の管理をするスクリプト
    private HookShot hookShot;              //そうめんが伸びるスクリプト
     
    private List<GameObject> humanList = new List<GameObject>();    //ジャンプした時に近くの人間をリストに格納する

    private int currentLevel = 0;   //そうめんの大きさのレベル

    private float waitTime = 0;     //そうめんを撃つクールダウンを待っている時間

    private Vector3 tempPos;        //ジャンプした瞬間のポジション
    private Vector3 startPos;       //座標ズレ対策のlocalTransform;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        playerManager = playerManageObj.GetComponent<PlayerManager>();
        jumpBlock = playerRotateAxis.GetComponent<JumpBlock>();
        hookShot = attackSoumen.GetComponent<HookShot>();

        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        shot();
    }

    /// <summary>
    /// ジャンプおよび着地時に縁に当たった瞬間の処理。
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //竹の縁に当たったらジャンプor着地処理
        if (other.gameObject.tag == "LeftJumpObj" || other.gameObject.tag == "RightJumpObj")
        {
            //isJumpがtrueの時当たる == 落下して帰ってきた時
            if (isJumpDown)
            {
                //着地した時に、位置ずれ対策としてlocalTransformにstartPosを代入
                transform.localPosition = startPos;

                isJump = false;
                isJumpDown = false;

                Time.timeScale = 1f;

                if (other.gameObject.tag == "LeftJumpObj")
                {
                    Debug.Log("changed");
                    jumpBlock.onLeftBlock = true;
                }
                if (other.gameObject.tag == "RightJumpObj")
                {
                    Debug.Log("changed");
                    jumpBlock.onRightBlock = true;
                }
            }
            else
            {
                //当たった瞬間近くにいる人間（そうめんを伸ばすターゲット）を探す
                SearchHuman();
                SoundFlagManager.isJump = true;
                isJump = true;
                
                Time.timeScale = 0.3f;
            }
        }
    }

    /// <summary>
    /// ジャンプの処理
    /// </summary>
    private void jump()
    {
        var jumpPos = transform.position;   //ジャンプ処理後のポジション

        if (isJump)
        {
            //ジャンプの上昇が終わっていなかったら
            if (!isJumpDown)
            {
                //ジャンプの時の座標を線形補完する
                jumpPos = Vector3.Lerp(jumpPos, new Vector3(tempPos.x, tempPos.y + playerManager.jumpHeight, tempPos.z),
                    Time.deltaTime * playerManager.jumpSpeed);
            }
            else
            {
                //落下時の座標を線形補完する
                jumpPos = Vector3.Lerp(jumpPos, tempPos, Time.deltaTime * playerManager.jumpSpeed);
            }

            //最高高度に達した場合落下処理に切り替える
            if (jumpPos.y > tempPos.y + playerManager.jumpHeight - 0.1f)
            {

                isJumpDown = true;
            }
        }
        else
        {
            //初めにジャンプした位置を記録
            tempPos = transform.position;
        }

        //ジャンプ処理後の最終的なポジションを格納
        transform.position = jumpPos;
    }

    /// <summary>
    /// そうめんから一定距離の人間をリストに格納するメソッド。近くにいるの要素数を返す。
    /// </summary>
    private void SearchHuman()
    {
        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Human"))
        {
            //自身と取得したオブジェクトの距離を取得
            float tmpDis = Vector3.Distance(obj.transform.position, transform.position);

            if (tmpDis < playerManager.shotRange)
            {
                humanList.Add(obj);
            }
        }
    }

    /// <summary>
    /// そうめんを撃つ処理
    /// </summary>
    private void shot()
    {
        if (waitTime < shotCoolDown)
        {
            waitTime += Time.deltaTime;
        }

        if (isJump)
        {
            if (humanList.Count > 0)
            {
                camera.transform.LookAt(humanList[humanList.Count - 1].transform);

                if (Mathf.Abs(MyJoyCon.joyconDec.accel.x ) + Mathf.Abs(MyJoyCon.joyconDec.accel.y)
                    + Mathf.Abs(MyJoyCon.joyconDec.accel.z) > triggerValue && waitTime >= shotCoolDown)
                {
                    waitTime = 0;

                    hookShot.target = humanList[humanList.Count - 1];
                    hookShot.trigger = true;

                    humanList.RemoveAt(humanList.Count - 1);
                }
            }
        }
    }
}
