using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDragAndCombo : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    public bool isBeingHeld = false;
    public GameObject child;
    public GameObject combotarget = null;
    public Transform currspawn;
    public GameObject spawn = null;
    private void Start()
    {
        currspawn = GetComponent<Tower>().spawnpos;
    }
    void Update()
    {
        if(isBeingHeld == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, currspawn.position, 50 * Time.deltaTime);
        }
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition= new Vector3(mousePos.x ,mousePos.y,-3);
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, -4);
        }
    }

    private void OnMouseDown()
    {

        print("lo3l");
        if (Input.GetMouseButtonDown(0))
        {


            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosX = mousePos.x - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }
    private void OnMouseUp()
    {
        isBeingHeld = false;
        child.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, -2);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, -1);

        if (combotarget != null)
        {
            combotarget.GetComponent<Tower>().lvl += GetComponent<Tower>().lvl;
            spawn.GetComponent<Collider2D>().enabled = !spawn.GetComponent<Collider2D>().enabled;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBeingHeld == true)
        {
            if (collision.CompareTag("Tower"))
            {
                print("In");

                combotarget = collision.gameObject;
            }
        }
    }
    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 1);
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(120, 120, 120, 1);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isBeingHeld == true)
        {
            if (collision.CompareTag("Tower"))
            {
                print("Out");
                combotarget = null;
            }
        }
    }
}
