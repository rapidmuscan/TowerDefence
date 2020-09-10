using TMPro;
using UnityEngine;

public class LvlTowerShow : MonoBehaviour
{
    #region Fields
    GameObject parent;
    #endregion
    #region Unity Methods
    private void Start()
    {
        parent = transform.parent.gameObject;

    }

    private void Update()
    {
        GetComponent<TextMeshPro>().text = ((int)parent.GetComponent<Tower>().lvl).ToString();
    }
    #endregion

}
