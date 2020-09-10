using UnityEngine;

public class Main : MonoBehaviour
{
    #region Fields
    public static Main Instance;

    public Web Web;
    public UserInfo UserInfo;
    public Login Login;
    public Items Items;
    public int progress = 0;
    public string RoomName = "";

    public GameObject UserProfile;
    #endregion
    #region Unity Methods
    void Start()
    {
        Instance = this; 
        Web = GetComponent<Web>();
        UserInfo = GetComponent<UserInfo>();
        DontDestroyOnLoad(gameObject);
    }
    #endregion
}
