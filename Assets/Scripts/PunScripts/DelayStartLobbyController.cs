using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class DelayStartLobbyController : MonoBehaviourPunCallbacks
{
    #region Fields
    [SerializeField]
    private GameObject quickstartButton;
    [SerializeField]
    private GameObject quickCancelButton;
    [SerializeField]
    private int roomsize;
    bool customroom = false;
    public InputField RoomNameInput;
    #endregion
    #region Custom Methods
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickstartButton.SetActive(true);
        
    }
    public void quickstart()
    {
        //quickstartButton.SetActive(false);
        //quickCancelButton.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
        
        print("quickstart");
    }
    public void CustomJoin()
    {
        PhotonNetwork.JoinRoom(RoomNameInput.text);
        print("Trying to Join");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Failedtojoin");
        CreateRoom();
    }
    public void CreateRoom()
    {
        print("Making room");
        int randomRoomNumber = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomsize };
        PhotonNetwork.CreateRoom("Quick Room" + randomRoomNumber, roomOps);
        print("Quick Room" + randomRoomNumber);
        Main.Instance.RoomName = "Quick Play";
    }
    public void CreateCustomRoom()
    {
        print("Making room");
        int randomRoomNumber = Random.Range(1000, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = false, IsOpen = true, MaxPlayers = (byte)roomsize };
        PhotonNetwork.CreateRoom(randomRoomNumber.ToString(), roomOps);
        print(randomRoomNumber);
        Main.Instance.RoomName = "Room Number :" + randomRoomNumber.ToString();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        if (customroom == false)
        {
            print("failedtocreateroom");
            CreateRoom();
        }
        else if (customroom == true)
        {
            CreateCustomRoom();
        }
    }

    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickstartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
    #endregion
}
