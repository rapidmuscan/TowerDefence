using Photon.Pun;
using System.IO;
using UnityEngine;
public class GameSetupController : MonoBehaviour
{
    #region Fields
    public GameObject camera1;
    public GameObject camera2;
    #endregion
    #region Unity Methods
    private void Start()
    {
        CreatePlayer();
    }
    private void Update()
    {

    }
    #endregion
    #region Custom Methods
    private void CreatePlayer()
    {
        print("CreatingPlayer");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), new Vector2(4, 0), Quaternion.identity);
            camera1.SetActive(true);
            camera1.tag = "MainCamera";
            //camera2.SetActive(true);
        }
        else if(!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), new Vector2(-4,0), Quaternion.identity);
            camera2.SetActive(true);
            camera2.tag = "MainCamera";
            //camera1.SetActive(true);
        }
    }
    #endregion

}
