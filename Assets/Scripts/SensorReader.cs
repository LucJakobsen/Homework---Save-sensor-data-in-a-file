using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SensorReader : MonoBehaviour
{


    public TMPro.TMP_Text text;
    

    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Debug.Log(Input.gyro.attitude);


        if(text)
            text.text = "Acceleration" + Input.acceleration.ToString();
    }
}
