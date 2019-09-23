using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadDisMeter : MonoBehaviour
{
    public Slider roadSlider;
    int stageInstantCount;
    public int plRoadPos;

    // Start is called before the first frame update
    void Start()
    {
        //初期値
        roadSlider.maxValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの現在地
        //plRoadPos = 0;

        //バーの変更
        roadSlider.value = plRoadPos;
    }
}
