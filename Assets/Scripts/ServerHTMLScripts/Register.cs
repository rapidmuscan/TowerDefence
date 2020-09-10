using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public Text ErrorField;
    public InputField ussernameInput;
    public InputField PasswordInput;
    public InputField PasswordInputConfirm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void onbuttonclick()
    {
        if (PasswordInput.text == PasswordInputConfirm.text)
        {
            StartCoroutine(Main.Instance.Web.RegisterUser(ussernameInput.text, PasswordInput.text, ErrorField));
        }
        else {
            ErrorField.text = "confirmpassword is wrong";
        }
    }


    void Update()
    {

    }
}
