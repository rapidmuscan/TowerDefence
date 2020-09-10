using Photon.Pun;
using UnityEngine;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    #region Fields
    [SerializeField]
    private int multiplayerSceneIndex;
    #endregion
    #region Unity Methods
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    #endregion
    #region Custom Methods
    public override void OnJoinedRoom()
    {
        print("Joined Room");
        StartGame();
    }

    private void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            print("StartingGame");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }
    #endregion
}
