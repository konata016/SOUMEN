using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollide : MonoBehaviour
{
    public bool isCollide; 

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
        //伸ばしたそうめんがターゲットに当たったら
        if (other.gameObject.tag == "Human")
        {
            isCollide = true;
        }
    }
}
