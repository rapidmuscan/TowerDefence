using SimpleJSON;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Items : MonoBehaviour
{
    #region Fields
    public GameObject PrefabofItem;
    Action<string> _createItemsCallback;
    #endregion
    #region Unity Methods
    void Start()
    {
        //_createItemsCallback = (jsonArrayString) =>
        //{
        //    StartCoroutine(CreateItemsRoutene(jsonArrayString));

        //}; 
        //CreateItems();
        refill();
    }
    #endregion
    #region Custom Methods
    public void refill()
    {
        _createItemsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateItemsRoutene(jsonArrayString));

        };
        CreateItems();
    }
    public void CreateItems()
    {
        string userId = Main.Instance.UserInfo.UserID;
        StartCoroutine(Main.Instance.Web.GetItemsIDs(userId, _createItemsCallback));
    }

    IEnumerator CreateItemsRoutene(string jsonArrayString)
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        //parcing json array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            //createfewvarubles
            bool isdone = false;
            string itemID = jsonArray[i].AsObject["itemID"];
            JSONObject itemInfoJson = new JSONObject();


            //create callback

            Action<string> getiteminfocallback = (itemInfo) =>
            {
                isdone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;
            };

            StartCoroutine(Main.Instance.Web.GetItem(itemID, getiteminfocallback));
            //wait untill callback is called from web (info finnished download)
            yield return new WaitUntil(() => isdone == true);

            //Instantiate a Prefab gameobject
            GameObject item = Instantiate(PrefabofItem);
            item.transform.SetParent(this.transform);
            item.transform.localScale = Vector3.one;
            item.transform.localPosition = Vector3.zero;

            //fill information

            item.transform.Find("Name").GetComponent<Text>().text = itemInfoJson["name"];
            item.transform.Find("Price").GetComponent<Text>().text = itemInfoJson["price"];
            item.transform.Find("Description").GetComponent<Text>().text = itemInfoJson["description"];
            //continiu to the next item
        }


    }
    #endregion
}
