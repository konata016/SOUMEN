using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{

    /* public変数*/
    public bool trigger = false;    //そうめんを伸ばすフラグ
    public GameObject target;       //そうめんを伸ばすターゲット

    /* --- SerializeFieldの変数 --- */
    [SerializeField] private GameObject attackSoumenEdge;   //伸ばすそうめん
    [SerializeField] private float shotSpeed;               //そうめんが伸びるスピード

    /* --- 変数 ---*/

    /* --- private変数 --- */
    private ShotCollide shotCollide;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //isTrigger = true;
        shotCollide = attackSoumenEdge.GetComponent<ShotCollide>();
    }

    // Update is called once per frame
    void Update()
    {
        SoumenStretch();
    }

    /// <summary>
    /// そうめんの伸び縮み処理
    /// </summary>
    void SoumenStretch()
    {
        var siz = transform.localScale;
        //var dis = Vector3.Distance(transform.position, target.transform.position);

        if (trigger)
        {
            transform.LookAt(target.transform);

            if (!shotCollide.isCollide)
            {
                //フックを伸ばす
                timer = Time.fixedTime * Time.fixedTime * shotSpeed;
                siz.z += timer;
            }
            else
            {
                //フックを縮める
                siz.z -= timer;
                timer = Time.fixedTime * Time.fixedTime * shotSpeed;

                //サイズが1以下になった時、1に戻す
                if (siz.z < 1)
                {
                    siz.z = 1;

                    //
                    trigger = false;
                    shotCollide.isCollide = false;

                    //ここにPlayerManager.AddSoumen()を記述することでそうめんを増やす。
                }
            }

        }
        transform.localScale = siz;
    }
}
