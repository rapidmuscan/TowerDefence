using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomName : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text =  Main.Instance.RoomName;
    }

    
}
