using TMPro;
using UnityEngine;

public class ShowLivesText : MonoBehaviour
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
        GetComponent<TextMeshPro>().text = ((int)parent.GetComponent<Enemy>().health).ToString();
    }
    #endregion

}
