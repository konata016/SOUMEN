using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBloc : MonoBehaviour
{
    public GameObject plCore;
    public GameObject pl;
    public static bool on { get; set; }

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

        if (roll.z > 100 && roll.z < 180)
        {
            roll.z = 80f;
            plCore.transform.rotation = Quaternion.Euler(roll);
        }
    }
}
