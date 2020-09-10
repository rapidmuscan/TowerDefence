using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;
public class ListPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int num = 0;
    void Start()
    {
        PhotonNetwork.LocalPlayer.NickName = Main.Instance.UserInfo.UserName;   
    }

    // Update is called once per frame
    void Update()
    {
        if (num == 1)
        {
            GetComponent<Text>().text = PhotonNetwork.PlayerList[0].NickName;
        }
        if (num == 2)
        {
            if (PhotonNetwork.PlayerList.Length == 2)
            {
                GetComponent<Text>().text = PhotonNetwork.PlayerList[1].NickName;
            }
        }
        
    }
}
