using System;
using UnityEngine;
using UnityEngine.UI;
public class time : MonoBehaviour
{
    #region Fields
    public float timeinsec = 0;
    #endregion
    #region Unity Methods

    void Update()
    {
        timeinsec += Time.deltaTime;
        GetComponent<Text>().text = TimeSpan.FromSeconds((int)timeinsec).ToString();
    }
    #endregion
}
