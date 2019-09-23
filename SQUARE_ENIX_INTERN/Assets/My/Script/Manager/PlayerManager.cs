using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	/*public struct PlayerParameter
	{
		public int HP;                      //そうめんの本数
		public float shotRange;             //そうめんを撃てる距離
		public float speed;                 //そうめんの速さ
		public float jumpHeight;            //ジャンプの高さ
		public float jumpSpeed;             //ジャンプの速さ
	}*/

	/* public変数*/
	public int HP;                      //そうめんの本数
	public float shotRange;             //そうめんを撃てる距離
	public float speed;                 //そうめんの速さ
	public float jumpHeight;            //ジャンプの高さ
	public float jumpSpeed;             //ジャンプの速さ

	//public struct PlayerParameter playerParameter = new PlayerParameter();                //プレイヤーのステータスを管理する構造体

	/* --- SerializeFieldの変数 --- */
	[SerializeField] private GameObject player;     //プレイヤーのゲームオブジェクト
    [SerializeField] private int damage = 100;      //そうめん中心部に当たった時の減る本数
    [SerializeField] private int[] volumeLevel;     //大きさが変わる本数の段階

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
        
    }

    /// <summary>
    /// 箸にぶつかった時にそうめんが減るスクリプト。箸オブジェクトから当たった場所を引数に呼び出されます。
    /// </summary>
    public void Damaged(Vector3 colPosition)
    {
        int changeIdx;  //どのレベルまでそうめんの大きさを変更するか
        float ratio;    //減る本数の割合

        BoxCollider boxCollider = GetComponent<BoxCollider>();

        //x軸における中心からの距離の割合
        ratio = 1 - (Mathf.Abs(colPosition.x - transform.position.x)) /
            (Mathf.Abs(transform.localScale.x * boxCollider.size.x) / 2);

        Debug.Log(100 * ratio);
        HP -= (int)(damage * ratio);

        for (int i = 0; i < volumeLevel.Length; i++)
        {
            if (HP < volumeLevel[i])
            {
                changeIdx = i;
                break;
            }
        }

        //この後にchangeIdxを使用し、そうめんの大きさを変更する処理を記述
    }

    /// <summary>
    /// そうめんが増える時のスクリプト。増える本数を引数に呼び出されます。
    /// </summary>
    public void AddSoumen(int soumenNum)
    {
        int changeIdx;  //どのレベルまでそうめんの大きさを変更するか

        HP += soumenNum;

        for (int i = 0; i < volumeLevel.Length; i++)
        {
            if (HP < volumeLevel[i])
            {
                changeIdx = i;
                break;
            }
        }

        //この後にchangeIdxを使用し、そうめんの大きさを変更する処理を記述
    }
}
