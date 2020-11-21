using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayStartRoomController : MonoBehaviourPunCallbacks
{
    #region Fields
    [SerializeField]
    private int waitingroomsceneindex;
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
        print("StartingGame");
        print(PhotonNetwork.CurrentRoom.Name);
    }
    #endregion
}
