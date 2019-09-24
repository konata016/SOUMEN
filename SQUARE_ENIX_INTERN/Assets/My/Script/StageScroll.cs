using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScroll : MonoBehaviour
{
    List<GameObject> stages = new List<GameObject>();
    public GameObject stageObj;
    public float speed = 5;

    public GameObject goalStagePart;

    public float gamePlayTime;
    public float currentTime = 0;

    private bool goalFrag = false;

    // Start is called before the first frame update
    void Start()
    {
        //初めにステージを10個生成しておく
        for (int i = 0; i < 10; i++)
        {
            stages.Add(Instantiate(stageObj, new Vector3(0, 0, i * 100), new Quaternion()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        //生成と廃棄を繰り返す
        foreach (GameObject stage in stages)
        {
            //ステージ移動
            //var pos = stage.transform.position;
            //pos.z -= speed * Time.deltaTime;
            //stage.transform.position = pos;

            stage.GetComponent<Rigidbody>().AddForce(speed * ((Vector3.back * speed) - stage.GetComponent<Rigidbody>().velocity));

            if (stage.transform.position.z < -200)
            {
                var tmpObj = stage;

                //ステージ生成

                if (!goalFrag)
                {
                    stages.Add(Instantiate(stageObj, new Vector3(0, 0, (stages.Count - 2) * 100), new Quaternion()));
                }
                else
                {
                    stages.Add(Instantiate(goalStagePart, new Vector3(0, 0, (stages.Count - 2) * 100), new Quaternion()));
                    goalFrag = false;
                    currentTime = 0;
                }

                //ステージの廃棄
                stages.RemoveAt(0);
                Destroy(tmpObj);
            }
        }

        if (currentTime > gamePlayTime)
        {
            goalFrag = true;
        }
    }
}
