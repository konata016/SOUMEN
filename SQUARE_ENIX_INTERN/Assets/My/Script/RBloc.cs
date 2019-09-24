using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBloc : MonoBehaviour
{

    public GameObject plCore;
    public static bool on { get; set; }
    public GameObject pl;

    Vector3 tmpPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var roll = plCore.transform.rotation.eulerAngles;

        if (tmpPos == Vector3.zero || tmpPos == null)
        {
            tmpPos = pl.transform.position;
        }

        if (roll.z < 255f && roll.z > 180f)
        {
            roll.z = 280f;
        }
        plCore.transform.rotation = Quaternion.Euler(roll);
    }
}
