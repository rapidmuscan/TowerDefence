using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDetails : MonoBehaviour
{
    public UserInfo _UserInfo;
    public Text ShowMoney;
    public Text ShowLevel;
    public Text ShowNickName;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowMoney.text = _UserInfo.Coins;
        ShowLevel.text = _UserInfo.Level;
        ShowNickName.text = _UserInfo.UserName;
    }
}
