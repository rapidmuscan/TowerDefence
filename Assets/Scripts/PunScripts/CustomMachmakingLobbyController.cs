using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomMachmakingLobbyController : MonoBehaviourPunCallbacks
{
    #region Fields
    [SerializeField]
    private GameObject lobbyconnectbutton;
    [SerializeField]
    private GameObject lobbyPanel;
    [SerializeField]
    private GameObject mainpanel;

    public InputField playerNameInput;
    private string roomName;
    private int roomsize;

    private List<RoomInfo> roomListings;
    [SerializeField]
    private Transform roomscontainer;
    [SerializeField]
    private GameObject roomListingPrefab;
    #endregion
    #region Unity Methods
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        lobbyconnectbutton.SetActive(true);
        roomListings = new List<RoomInfo>();

        if (PlayerPrefs.HasKey("NickName"))
        {
            if (PlayerPrefs.GetString("NickName")=="")
            {
                PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
            }
            else
            {
                PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");
            }
        }
        else
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0,1000);
        }
        playerNameInput.text = PhotonNetwork.NickName;
    }


    public void PlayerNameUpdate(string nameInput)
    {
        PhotonNetwork.NickName = nameInput;
        PlayerPrefs.SetString("NickName",nameInput);
        playerNameInput.text = nameInput;
    }
    public void JoinLobbyOnClick()
    {
        mainpanel.SetActive(false);
        lobbyPanel.SetActive(true);
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int tempIndex;
        foreach (RoomInfo room in roomList)
        {
            if(roomListings != null)
            {
                tempIndex = roomListings.FindIndex(ByName(room.Name));
            }
            else
            {
                tempIndex = -1;
            }
            if(tempIndex != -1)
            {
                roomListings.RemoveAt(tempIndex);
                Destroy(roomscontainer.GetChild(tempIndex).gameObject);
            }
            if(room.PlayerCount > 0)
            {
                roomListings.Add(room);
                ListRoom(room);
            }
        }
    }

    private void ListRoom(RoomInfo room)
    {
        if (room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab, roomscontainer);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.SetRoom(room.Name,room.MaxPlayers,room.PlayerCount);
        }
    }

    static System.Predicate<RoomInfo> ByName(string name)
    {
        return delegate (RoomInfo room)
        {
            return room.Name == name;
        };
    }

    public void OnRoomNameChanged(string nameIn)
    {
        roomName = nameIn;
    }
    public void OnRoomSizeChanged(string sizeIn)
    {
        roomsize = int.Parse(sizeIn);
    }

    public void CreateRoom()
    {
        print("CreatingRoom");
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomsize };
        PhotonNetwork.CreateRoom(roomName, roomOps);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("FailedToLogIn");
    }

    public void MatchmakingCancel()
    {
        mainpanel.SetActive(true);
        lobbyPanel.SetActive(false);
        PhotonNetwork.LeaveLobby();
    }
    #endregion

}
