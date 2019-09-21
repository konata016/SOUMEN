using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlMove : MonoBehaviour
{
    public float speed = 10;


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

    struct PlayerParameter
    {
        public float speed;
    }
    PlayerParameter plParam = new PlayerParameter();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var roll = transform.rotation.eulerAngles;
        roll.z += speed * joyconDec.accel.y;

        transform.rotation = Quaternion.Euler(roll);
    }

    void Parameter(float timer)
    {
        plParam.speed = speed * timer;
    }

    void GetJoyCon()
    {

        //後できれいにする

        joyconDec.isLeft = m_joycons[1].isLeft;
        //joyconDec.button = joyconDec.isLeft ? m_pressedButtonL : m_pressedButtonR;
        joyconDec.stick = m_joycons[1].GetStick();
        joyconDec.gyro = m_joycons[1].GetGyro();
        joyconDec.accel = m_joycons[1].GetAccel();
        joyconDec.orientation = m_joycons[1].GetVector();
    }
}
