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
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isJump)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 3);
            transform.rotation = Quaternion.Euler(defaultCameraAngle);
        }
    }

    public void setDefaultRotate()
    {
        transform.rotation = Quaternion.Euler(defaultCameraAngle);
    }
}
