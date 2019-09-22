using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSoumen : MonoBehaviour
{
    public static bool onSoumen; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //素麺に触れた場合フラグを立てる
        if (other.gameObject.tag == "Soumen")
        {
            onSoumen = true;
        }
    }
}
