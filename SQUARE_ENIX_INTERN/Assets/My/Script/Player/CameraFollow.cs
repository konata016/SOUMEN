using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /* public変数*/

    /* --- SerializeFieldの変数 --- */
    [SerializeField] private GameObject player;     //プレイヤーのゲームオブジェクト
    [SerializeField] new Vector3 defaultCameraAngle;

    /* --- 変数 ---*/

    /* --- private変数 --- */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 3);
    }

    public void setDefaultRotate()
    {
        transform.rotation = Quaternion.Euler(defaultCameraAngle);
    }
}
