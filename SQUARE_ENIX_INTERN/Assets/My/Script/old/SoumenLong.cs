using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class SoumenLong : MonoBehaviour
{
    int soumenSiz;


    public List<GameObject> obiObj = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //入っているプレハブを調べる
        Debug.Log(transform.GetChildCount());
        for (int i = 0; i < transform.GetChildCount(); i++)
        {
            obiObj.Add(transform.GetChild(i).gameObject.transform.GetChild(0).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SoumenSizChange();
    }

    void SoumenSizChange()
    {
        for (int i=0; i < transform.GetChildCount(); i++) {

            switch (Score.scoreRank)
            {
                case Score.RANK.Ryou: soumenSiz = 1; break;
                case Score.RANK.Yuu: soumenSiz = 2; break;
                case Score.RANK.Syuu: soumenSiz = 3; break;
                default: break;
            }

            //obi.GetComponent<ObiDistanceConstraints>().stretchingScale = soumenSiz;
            obiObj[i].GetComponent<ObiRopeCursor>().ChangeLength((float)soumenSiz * 1.5f);
        }
    }
}
