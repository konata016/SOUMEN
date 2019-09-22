using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlJump : MonoBehaviour
{
    bool isJumpEnd;
    Vector3 tmpPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var parentRoll = transform.root.gameObject.transform.rotation;
        var plParam = PlMove.plParam;

        if (plParam.isJump)
        {
            //if (!isJumpEnd) pos = Vector3.Lerp(pos, new Vector3(tmpPos.x, tmpPos.y + plParam.high * 4, tmpPos.z), plParam.speed);
            //else
            //{

            //    if (tmpPos.y > pos.y) plParam.isJump = false;
            //    else
            //    {
            //        pos.y -= plParam.speed;
            //    }
            //}

            //if (pos.y <= tmpPos.y + plParam.high * 4)
            //{
            //    if (parentRoll.z < 90)
            //    {
            //        plParam.isJump = false;
            //        parentRoll = Quaternion.Euler(new Vector3(0, 0, 89));
            //        transform.root.gameObject.transform.rotation = parentRoll;
            //    }
            //    isJumpEnd = true;     
            //}

        }
        else
        {
            tmpPos = transform.position;
        }

        transform.position = pos;
        

        Debug.Log(plParam.isJump);
    }
}
