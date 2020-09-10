using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartlobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickstartButton;
    [SerializeField]
    private GameObject quickCancelButton;
    [SerializeField]
    private int roomsize;
    // Start is called before the first frame update
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickstartButton.SetActive(true);
    }
    public void quickstart()
    {
        quickstartButton.SetActive(false);
        quickCancelButton.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
        print("quickstart");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Failedtojoin");
        CreateRoom();
    }
    void CreateRoom()
    {
        print("Making room");
        int randomRoomNumber = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomsize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        print(randomRoomNumber);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("failedtocreateroom");
        CreateRoom();
    }

    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickstartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
