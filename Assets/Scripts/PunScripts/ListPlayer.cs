using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
public class ListPlayer : MonoBehaviour
{
    #region Fields
    public int num = 0;
    #endregion
    #region Unity Methods
    void Start()
    {
        PhotonNetwork.LocalPlayer.NickName = Main.Instance.UserInfo.UserName;   
    }

    void Update()
    {
        if (num == 1)
        {
            GetComponent<Text>().text = PhotonNetwork.PlayerList[0].NickName;
        }
        if (num == 2)
        {
            if (PhotonNetwork.PlayerList.Length == 2)
            {
                GetComponent<Text>().text = PhotonNetwork.PlayerList[1].NickName;
            }
        }
        
    }
    #endregion
}
