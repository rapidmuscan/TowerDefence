using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Text ErrorField;
    public InputField ussernameInput;
    public InputField PasswordInput;
    public Button loginButton;
    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(()=> {
           StartCoroutine( Main.Instance.Web.Login(ussernameInput.text, PasswordInput.text, ErrorField));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
