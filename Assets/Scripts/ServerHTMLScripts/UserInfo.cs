using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
public class UserInfo : MonoBehaviour
{
    public string UserID { get; private set; }
    public string UserName { get; private set; }

    string UserPassword;
    public string Level { get; private set; }
    public string Coins { get; private set; }
    public string jsonString = "";
    bool check1 = false;
    bool check2 = false;
    bool check3 = false;
    bool check4 = false;
    bool check5 = false;
    bool check6 = false;
    private void Start()
    {
        UserID = "";
        UserName = "";
        UserPassword = "";
        Level = "";
        Coins = "";
        jsonString = "";
    }

    public void SetCredentials(string username, string userpassword)
    {
        UserName = username;
        UserPassword = userpassword;
        StartCoroutine(Main.Instance.Web.GetCoinsAndLevel(UserName, UserPassword));

    }
    public void SetID(string id)
    {
        UserID = id;
    }
    public void BuyItem(string itemID)
    {
        StartCoroutine(Main.Instance.Web.BuyItem(itemID));
    }
    private void Update()
    {
        if(jsonString != "")
        {
            UpdateJsonDataLevelCoin();
        }


        if (UserID != "" && check1 == false)
        {
            Main.Instance.progress += 1;
            check1 = true;
            print(1);
        }
        if (UserName != "" && check2 == false)
        {
            Main.Instance.progress += 1;
            check2 = true;
            print(2);
        }
        if (UserPassword != "" && check3 == false)
        {
            Main.Instance.progress += 1;
            check3 = true;
            print(3);
        }
        if (Level != "" && check4 == false)
        {
            Main.Instance.progress += 1;
            check4 = true;
            print(4);
        }
        if (Coins != "" && check5 == false)
        {
            Main.Instance.progress += 1;
            check5 = true;
            print(5);
        }
        if (jsonString != "" && check6 == false)
        {
            check6 = true;
            print(6);
            Main.Instance.progress += 1;
        }





    }
    void UpdateJsonDataLevelCoin()
    {
        JSONObject itemInfoJson = new JSONObject();

        JSONArray tempArray = JSON.Parse(jsonString) as JSONArray;

        itemInfoJson = tempArray[0].AsObject;

        Level = itemInfoJson["level"];
        Coins = itemInfoJson["coins"];

    }

}
