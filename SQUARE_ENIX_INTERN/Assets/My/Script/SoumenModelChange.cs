using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoumenModelChange : MonoBehaviour
{
    List<GameObject> soumenObjList = new List<GameObject>();
    int SoumenSiz;
    // Start is called before the first frame update
    void Start()
    {
        //入っているプレハブを調べる
        foreach (Transform child in transform)
        {
            soumenObjList.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //代入用
        //SoumenSiz

        //現在のサイズのプレハブをアクティブにしてそれ以外を非表示にする
        if (Input.anyKeyDown) SoumenSiz++;
        for (int i = 0; i < soumenObjList.Count; i++)
        {
            if (SoumenSiz == i)
            {
                soumenObjList[i].SetActive(true);
            }
            else
            {
                soumenObjList[i].SetActive(false);
            }
        }
    }
}