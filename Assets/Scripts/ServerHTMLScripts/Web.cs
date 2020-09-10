using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class Web : MonoBehaviour
{
    #region Unity Methods
    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetDate("http://u1015076.cp.regruhosting.ru/GetDate.php"));
        //StartCoroutine(GetUsers("http://u1015076.cp.regruhosting.ru/Game/GetUsers.php"));
        //StartCoroutine(Login("testuser", "12345"));
        //StartCoroutine(RegisterUser("testuser4", "12345"));

        //// A non-existing page.
        //StartCoroutine(GetDate("http://localhost/"));
    }
    #endregion

    #region Custom Methods
    public IEnumerator GetDate(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetUsers(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
    public IEnumerator Login(string username, string password,Text ErrorField)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://u1015076.cp.regruhosting.ru/Game/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                ErrorField.text = www.error;
            }
            else
            {
                ErrorField.text = www.downloadHandler.text;
                Main.Instance.UserInfo.SetCredentials(username,password);
                Main.Instance.UserInfo.SetID(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("wrong password") || www.downloadHandler.text.Contains("username does not exists"))
                {
                    print("Try Again");
                }
                else {
                    //if login currect
                    Main.Instance.UserProfile.SetActive(true);
                    Main.Instance.Login.gameObject.SetActive(false);
                }
                }
        }
    }
    public IEnumerator RegisterUser(string username, string password,Text ErrorField)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://u1015076.cp.regruhosting.ru/Game/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                ErrorField.text = www.error;
            }
            else
            {
                ErrorField.text = www.downloadHandler.text;
            }
        }
    }

    public IEnumerator GetItemsIDs(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);

        string uri = "http://u1015076.cp.regruhosting.ru/Game/GetItemsIDs.php";
        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                string jsonArray = webRequest.downloadHandler.text;
                //call calback function to pass results

                callback(jsonArray);
            }
        }
    }
    public IEnumerator GetItem(string itemID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);

        string uri = "http://u1015076.cp.regruhosting.ru/Game/GetItem.php";
        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                string jsonArray = webRequest.downloadHandler.text;
                //call calback function to pass results

                callback(jsonArray);
            }
        }
    }
    public IEnumerator BuyItem(string itemID)
    {
        print("lol");
        string userID = Main.Instance.UserInfo.UserID;
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);
        form.AddField("userID", userID);

        string uri = "http://u1015076.cp.regruhosting.ru/Game/BuyItem.php";
        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                //call calback function to pass results
                Main.Instance.Items.refill();
            }
        }
    }


    public IEnumerator GetCoinsAndLevel(string loginUser, string loginPass)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", loginUser);
        form.AddField("loginPass", loginPass);

        string uri = "http://u1015076.cp.regruhosting.ru/Game/GetUserInfophp.php";
        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                string jsonArray = webRequest.downloadHandler.text;
                //call calback function to pass results
                print(webRequest.downloadHandler.text);
                Main.Instance.UserInfo.jsonString = jsonArray;
            }
        }
    }
    #endregion
}
