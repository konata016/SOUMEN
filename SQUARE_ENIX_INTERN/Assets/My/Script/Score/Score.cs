using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int SoumenCount;
    int maxSoumenCount;



    struct Rank
    {
        public float ryou;
        public float yuu;
        public float syuu;
    }
    Rank rank = new Rank();

    enum SCORE {
        Huka,Ryou,Yuu,Syuu
    }

    // Start is called before the first frame update
    void Start()
    {
        //初期値
        SoumenCount = 10;
        rank.ryou = maxSoumenCount / 3;
        //rank.yuu
        

    }

    // Update is called once per frame
    void Update()
    {
        if (SoumenCount > 0)
        {

        }
        //if(SoumenCount<)
    }
}
