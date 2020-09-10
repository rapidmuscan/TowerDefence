using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    #region Fields
    public Text ErrorField;
    public InputField ussernameInput;
    public InputField PasswordInput;
    public InputField PasswordInputConfirm;
    #endregion
    #region Unity Methods
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}
    #endregion
    #region Custom Methods
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
    #endregion


}
