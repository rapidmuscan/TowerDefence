using Photon.Pun;

public class NetworkController : MonoBehaviourPunCallbacks
{
    #region Unity Methods
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // void Update()
    // {

    //  }
    #endregion
    #region Custom Methods
    public override void OnConnectedToMaster()
    {
        print("we are connected " + PhotonNetwork.CloudRegion);
    }
    #endregion
}
