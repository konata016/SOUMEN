using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadDisMeter : MonoBehaviour
{
    public Slider roadSlider;
    int stageInstantCount;
    public int plRoadPos;
    public StageScroll stageScroll;

    // Start is called before the first frame update
    void Start()
    {
        

        //初期値
        roadSlider.maxValue = stageScroll.goalPosCount;

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの現在地
        plRoadPos = stageScroll.plPosCount;

        //バーの変更
        roadSlider.value = plRoadPos;
    }
}
