using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    float timer;
    public static bool isTrigger { get; set; }
    public float speed;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        var siz = transform.localScale;
        //var dis = Vector3.Distance(transform.position, target.transform.position);

        if (isTrigger)
        {
            transform.LookAt(target.transform);

            if (!GetSoumen.onSoumen)
            {
                //フックを伸ばす
                timer = Time.fixedTime * Time.fixedTime * speed;
                siz.z += timer;
            }
            else
            {
                //フックを縮める
                siz.z -= timer;
                timer = Time.fixedTime * Time.fixedTime * speed;

                //サイズが1以下になった場合1地に1に戻す
                if (siz.z < 1)
                {
                    siz.z = 1;

                    //
                    isTrigger = false;
                }
            }
            
        }
        transform.localScale = siz;
    }
}
