using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoumenShot2 : MonoBehaviour
{
    /* --- 定数 --- */

    /* public変数*/
    public static bool jumpTrigger { get; set; }
    public Camera camera;

    /* --- SerializeFieldの変数 --- */
    [SerializeField] private float triggerValue;        //そうめんを撃つ角度変化のボーダー
    [SerializeField] private float coolDown = 0;     //そうめんを撃つ判定のクールダウンの設定値
    [SerializeField] private GameObject soumenTerminal;

    /* --- 変数 ---*/

    /* --- private変数 --- */
    private int shotNum = 0;        //デバッグ用。そうめんを撃つことができると1ずつ増える。
    private float waitTime = 0;     //そうめんを撃つクールダウンを待っている時間

    private List<GameObject> humanList = new List<GameObject>();    //ジャンプした時に近くの人間をリストに格納する
    private SoumenStatus soumenStatus;  //そうめんのステータスを管理するスクリプト
    private HookShot hookShot;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        soumenStatus = GetComponent<SoumenStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        //デバッグ用。jumpしたという判定。
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpTrigger = true;
            SearchHuman();
        }


        if (waitTime < coolDown)
        {
            waitTime += Time.deltaTime;
        }

        if (jumpTrigger)
        {
            if (humanList.Count > 0)
            {
                camera.transform.LookAt(humanList[humanList.Count - 1].transform);

                if (Input.GetKey(KeyCode.I)
                    && waitTime >= coolDown)
                {
                    shotNum++;
                    waitTime = 0;
                    Debug.Log("shot : " + shotNum);

                    //while () { }/

                    humanList.RemoveAt(humanList.Count - 1);
                }
            }
        }
    }



    /// <summary>
    /// そうめんから一定距離の人間をリストに格納するメソッド。近くにいるの要素数を返す。
    /// </summary>
    public void SearchHuman()
    {
        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Human"))
        {
            //自身と取得したオブジェクトの距離を取得
            float tmpDis = Vector3.Distance(obj.transform.position, transform.position);

            Debug.Log(tmpDis);

            if (tmpDis < soumenStatus.shotRange)
            {
                humanList.Add(obj);
            }
        }
    }
}
