using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("we are connected " + PhotonNetwork.CloudRegion );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
