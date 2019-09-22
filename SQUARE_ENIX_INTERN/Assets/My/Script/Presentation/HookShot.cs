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

            if (!GetSoumen.onSoumen)
            {
                timer = Time.fixedTime * Time.fixedTime * speed;
                siz.x += timer;
            }
            else
            {
                siz.x -= timer;
                timer = Time.fixedTime * Time.fixedTime * speed;
                if (siz.x < 0)
                {
                    siz.x = 1;
                    isTrigger = false;
                }
            }
            
        }
        transform.localScale = siz;
    }
}
