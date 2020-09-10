using UnityEngine;
using UnityEngine.UI;

public class RoomName : MonoBehaviour
{
    #region Unity Methods
    void Start()
    {
        GetComponent<Text>().text =  Main.Instance.RoomName;
    }
    #endregion

}
