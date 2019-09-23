using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasiMove : MonoBehaviour
{
    public GameObject pl;
    public float actStart = 10;
    public float speed = 5;

    GameObject hasi;
    bool onTrigger;
   
    // Start is called before the first frame update
    void Start()
    {
        hasi = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        var dis = Vector3.Distance(transform.position, pl.transform.position);
        var hasiPos = hasi.transform.position;

        if (dis < actStart)
        {
            if (!onTrigger)
            {
                hasiPos.y -= speed * Time.deltaTime;
            }
        }
        hasi.transform.position = hasiPos;
    }

    //IEnumerator WaitTime(float timer)
    //{
    //    Debug.Log("aaa");
    //    onTrigger = true;
    //    yield return new WaitForSeconds(timer);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hasi")
        {
            onTrigger = true;
            //StartCoroutine("WaitTime", 100f);
        }
    }
}
