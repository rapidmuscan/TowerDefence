using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    #region Fields
    public Text ErrorField;
    public InputField ussernameInput;
    public InputField PasswordInput;
    public Button loginButton;
    #endregion
    #region Unity Methods
    void Start()
    {
        loginButton.onClick.AddListener(()=> {
           StartCoroutine( Main.Instance.Web.Login(ussernameInput.text, PasswordInput.text, ErrorField));
        });
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
    #endregion
}
