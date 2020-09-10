using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text sizeText;

    private string roomName;
    private int roomSize;
    private int _playerCount;
    #endregion
    #region Custom Methods
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
    #endregion
}
