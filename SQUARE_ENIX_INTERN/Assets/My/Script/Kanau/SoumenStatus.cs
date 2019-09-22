using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// そうめんのHPを減らすためのテストスクリプト
/// </summary>
public class SoumenStatus : MonoBehaviour
{
    /* --- 定数 --- */

    /* public変数*/
    public int HP = 100;                    //そうめんの本数

    /* --- SerializeFieldの変数 --- */
    [SerializeField] private int damage = 100;      //そうめん中心部に当たった時の減る本数
    [SerializeField] private int[] volumeLevel;       //大きさが変わる本数の段階

    /* --- 変数 ---*/

    /* --- private変数 --- */
    private int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// 箸にぶつかった時にそうめんが減るスクリプト。
    /// 箸オブジェクトから呼び出されます。
    /// </summary>
    /// <param name="colPosition"></param>
    public void Damaged(Vector3 colPosition)
    {
        float ratio;    //減る本数の割合
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        //x軸における中心からの距離の割合
        ratio = 1 - (Mathf.Abs(colPosition.x - transform.position.x)) /
            (Mathf.Abs(transform.localScale.x * boxCollider.size.x) / 2);

        Debug.Log(100 * ratio);
        HP -= (int)(damage * ratio);

        //
        for (int i = 0; i < volumeLevel.Length; i++)
        {
            if (HP < volumeLevel[i])
            {
                break;
            }
        }
    }

    /// <summary>
    /// テスト用の移動メソッド(AWSD)です。
    /// </summary>
    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, 0, 0.1f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -0.1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.1f, 0, 0);
        }
    }
}
