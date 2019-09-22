using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// そうめんが箸に当たった時の処理
/// </summary>
public class Damage : MonoBehaviour
{
    /* public変数*/

    /* SerializeField変数 */

    /* 変数 */

    /* private変数 */
    private SoumenStatus soumenStatus;      //そうめんの本数などを管理するスクリプト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<SoumenStatus>().Damaged(transform.position);
        }
    }
}
