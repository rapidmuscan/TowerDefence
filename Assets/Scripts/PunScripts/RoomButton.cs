using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text sizeText;

    private string roomName;
    private int roomSize;
    private int _playerCount;

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(roomName);
    }


    public void SetRoom(string name, int maxPlayers, int playerCount)
    {
        roomName = name;
        roomSize = maxPlayers;
        _playerCount = playerCount;
        nameText.text = name;
        sizeText.text = playerCount + "/" + maxPlayers;
    }
}
