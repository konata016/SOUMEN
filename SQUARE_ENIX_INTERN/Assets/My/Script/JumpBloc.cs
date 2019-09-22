using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBloc : MonoBehaviour
{

    public static bool onLeft;
    public static bool onRight;
    public float slide = 3;
    public float coldTime = 0.01f;
    public static bool landing;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var roll = transform.rotation.eulerAngles;
        if (landing)
        {
            timer += Time.deltaTime * 0.1f;

            //0.01秒間操作を受け付けず、中央に向かって自動的に移動する
            if (timer < coldTime)
            {
                if (onRight)
                {
                    //右のヘリに着地した時
                    roll.z -= slide * Time.deltaTime;
                }
                if (onLeft)
                {
                    //左のヘリに着地した時
                    roll.z += slide * Time.deltaTime;
                }
            }
            else
            {
                onLeft = false;
                onRight = false;
                landing = false;
                PlMove.plParam.isJump = false;
            }
        }
        else
        {
            //時間をリセットする
            timer = 0f;
        }
        transform.rotation = Quaternion.Euler(roll);

        
    }
}
