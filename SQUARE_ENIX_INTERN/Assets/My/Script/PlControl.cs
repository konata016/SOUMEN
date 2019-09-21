using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlControl : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
         Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    private Joycon.Button? m_pressedButtonL;
    private Joycon.Button? m_pressedButtonR;

    struct JoyConDec
    {
        public bool isLeft;
        public Joycon.Button button;
        public float[] stick;
        public Vector3 gyro;
        public Vector3 accel;
        public Quaternion orientation;

    }
    JoyConDec joyconDec = new JoyConDec();

    //消すやつ
    Rigidbody rb;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);

        //消すやつ
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



        //消すやつ
        //rb.AddForce(speed * ((joyconDec.orientation.eulerAngles * speed) - rb.velocity));
        var plPos = transform.position;
        plPos.x += joyconDec.accel.x * speed*Time.deltaTime;
        transform.position = plPos;
        Debug.Log(joyconDec.accel);
    }

    void GetJoyCon()
    {




        foreach (var joycon in m_joycons)
        {
            joyconDec.isLeft = joycon.isLeft;
            //joyconDec.button = joyconDec.isLeft ? m_pressedButtonL : m_pressedButtonR;
            joyconDec.stick = joycon.GetStick();
            joyconDec.gyro = joycon.GetGyro();
            joyconDec.accel = joycon.GetAccel();
            joyconDec.orientation = joycon.GetVector();
        }


    }
}
