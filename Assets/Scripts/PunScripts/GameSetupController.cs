using Photon.Pun;
using System.IO;
using UnityEngine;
using EZCameraShake;
public class GameSetupController : MonoBehaviour
{
    #region Fields
    public GameObject camera;
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
            camera.GetComponent<CameraShaker>().RestPositionOffset = new Vector3(-4.8f,2.48f,0);
            //camera2.SetActive(true);
        }
        else if(!PhotonNetwork.IsMasterClient)
        {
            camera.GetComponent<CameraShaker>().RestPositionOffset = new Vector3(24.66f, 2.48f, 0);
            //camera1.SetActive(true);
        }
    }
    #endregion

}
