using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MyJoyCon : MonoBehaviour
{
    float timer;


    private static readonly Joycon.Button[] m_buttons =
         Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    private Joycon.Button? m_pressedButtonL;
    private Joycon.Button? m_pressedButtonR;

    public struct JoyConDec
    {
        public bool isLeft;
        public Joycon.Button button;
        public float[] stick;
        public Vector3 gyro;
        public Vector3 accel;
        public Quaternion orientation;

        public float shuffleGage;

    }
    public static JoyConDec joyconDec = new JoyConDec();

    // Start is called before the first frame update
    void Start()
    {
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);
    }

    // Update is called once per frame
    void Update()
    {
        

        SetJoyCon();
        JoyConAction(timer);

        timer += 0.1f * Time.deltaTime;
        joyconDec.shuffleGage += m_joycons[1].GetGyro().x + m_joycons[1].GetGyro().y + m_joycons[1].GetGyro().z;
        if (timer < 0.01f)
        {
            //joyconDec.shuffleGage = 0;
            timer = 0;
        }
        Debug.Log(joyconDec.shuffleGage);
    }

    void SetJoyCon()
    {
        //
        joyconDec.isLeft = m_joycons[1].isLeft;
        joyconDec.stick = m_joycons[1].GetStick();
        joyconDec.gyro = m_joycons[1].GetGyro();
        joyconDec.accel = m_joycons[1].GetAccel();
        joyconDec.orientation = m_joycons[1].GetVector();
    }

    void JoyConAction(float timer)
    {

    }

    
}
