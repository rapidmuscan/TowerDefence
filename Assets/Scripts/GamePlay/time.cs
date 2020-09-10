using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class time : MonoBehaviour
{
    public float timeinsec = 0;
    void Update()
    {
        timeinsec += Time.deltaTime;
        GetComponent<Text>().text = TimeSpan.FromSeconds((int)timeinsec).ToString();
    }
}
