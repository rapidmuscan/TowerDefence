using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLivesText : MonoBehaviour
{
    GameObject parent;

    private void Start()
    {
        parent = transform.parent.gameObject;
        
    }

    private void Update()
    {
        GetComponent<TextMeshPro>().text = ((int)parent.GetComponent<Enemy>().health).ToString();
    }
}
