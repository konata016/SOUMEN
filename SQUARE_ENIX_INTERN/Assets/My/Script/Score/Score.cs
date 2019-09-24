using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    int soumenCount;
    public int maxSoumenCount;
    public static RANK scoreRank { get; set; }

    public Sprite[] spriteArray = new Sprite[4];
    public GameObject imageObj;
    public GameObject txt;
    

    //デバッグ用
    public int score;

    struct Rank
    {
        public float ryou;
        public float yuu;
        public float syuu;
    }
    Rank rank = new Rank();

    public enum RANK
    {
        Huka, Ryou, Yuu, Syuu
    }

    // Start is called before the first frame update
    void Start()
    {
        //初期値
        soumenCount = score;

        //
        rank.ryou = maxSoumenCount / 3;
        rank.yuu = rank.ryou + rank.ryou;
        rank.syuu = maxSoumenCount;
    }

    // Update is called once per frame
    void Update()
    {
        soumenCount = score;

        scorejudge();
        Ranking();

    }

    void Ranking()
    {
        //switch (scoreRank)
        //{
        //    case RANK.Huka:break;
        //    case RANK.Ryou:break;
        //    case RANK.Yuu:break;
        //    case RANK.Syuu:break;
        //    default:break;
        //}

        //結果を表示
        imageObj.GetComponent<Image>().sprite = spriteArray[(int)scoreRank];
        txt.GetComponent<TextMeshProUGUI>().text = "" + soumenCount;
    }

    void scorejudge()
    {
        //評価によって結果を判定する
        if (soumenCount <= 0)
        {
            scoreRank = RANK.Huka;
            Debug.Log("不可");
        }
        else if (soumenCount <= rank.ryou && soumenCount > 0)
        {
            scoreRank = RANK.Ryou;
            Debug.Log("良");
        }
        else if (soumenCount <= rank.yuu && soumenCount > rank.ryou)
        {
            scoreRank = RANK.Yuu;
            Debug.Log("優");
        }
        else if (soumenCount <= rank.syuu && soumenCount > rank.ryou)
        {
            scoreRank = RANK.Syuu;
            Debug.Log("修");
        }
    }
}
