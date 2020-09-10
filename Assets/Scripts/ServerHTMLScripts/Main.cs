using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Web Web;
    public UserInfo UserInfo;
    public Login Login;
    public Items Items;
    public int progress = 0;
    public string RoomName = "";

    public GameObject UserProfile;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
        Web = GetComponent<Web>();
        UserInfo = GetComponent<UserInfo>();
        DontDestroyOnLoad(gameObject);
    }

}
