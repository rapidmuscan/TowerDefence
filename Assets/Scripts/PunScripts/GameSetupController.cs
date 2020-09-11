using Photon.Pun;
using System.IO;
using UnityEngine;
using EZCameraShake;
public class GameSetupController : MonoBehaviour
{
    #region Fields
    public GameObject camera;
    public GameObject CameraRenderer;
    public GameObject ObjectView;
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
            camera.GetComponent<CameraShaker>().RestPositionOffset = new Vector3(-2.14f, 2.48f,0);
            CameraRenderer.transform.localPosition = new Vector3(24.66f, 2.48f, 0);
            ObjectView.transform.localPosition = new Vector3(-6f, 4.5f,13.71f);
            //camera2.SetActive(true);
        }
        else if(!PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), new Vector2(-4, 0), Quaternion.identity);
            camera.GetComponent<CameraShaker>().RestPositionOffset = new Vector3(24.66f, 2.48f, 0);
            CameraRenderer.transform.localPosition = new Vector3(-2.14f, 2.48f, 0);
            ObjectView.transform.localPosition = new Vector3(19.7f, 4.5f, 13.71f);
            //camera1.SetActive(true);
        }
    }
    #endregion

}
