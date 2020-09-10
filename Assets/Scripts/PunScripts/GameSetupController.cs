using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameSetupController : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    private void Start()
    {
        CreatePlayer();
    }

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
    private void Update()
    {

    }
}
