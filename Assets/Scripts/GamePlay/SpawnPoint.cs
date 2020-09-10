using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject towertospawn;
    public GameObject currtower = null;
    void Start()
    {

        gameObject.GetComponent<SpriteRenderer>().color = new Color(120, 120, 120, 0.10f);
        currtower = Instantiate(towertospawn, transform.position, Quaternion.identity);
        currtower.GetComponent<Tower>().spawnpos = transform;
        //currtower.GetComponent<TowerDragAndCombo>().spawn = gameObject;
        GetComponent<Collider2D>().enabled = !GetComponent<Collider2D>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(120, 120, 120, 0.28f);
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(120, 120, 120, 0.10f);
    }

    public void SpawnTower()
    {

        currtower = Instantiate(towertospawn, transform.position, Quaternion.identity);
        currtower.GetComponent<Tower>().spawnpos = transform;
        //currtower.GetComponent<TowerDragAndCombo>().spawn = gameObject;
            GetComponent<Collider2D>().enabled = !GetComponent<Collider2D>().enabled;
        
    }
}
