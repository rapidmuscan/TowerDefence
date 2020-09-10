using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int score = 100;

    private void Update()
    {
        //    if (score >= 10)
        //    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                GameObject curobj = hit.collider.gameObject;
                if (curobj.tag == "SpawnPoint" && curobj.GetComponent<SpawnPoint>().currtower == null)
                {

                    curobj.GetComponent<SpawnPoint>().SpawnTower();
                }
                if (curobj.tag == "Tower") {
                    if (hit.collider.gameObject.GetComponent<Tower>().lvl < 100)
                    {
                        hit.collider.gameObject.GetComponent<Tower>().lvl += 1;

                        hit.collider.gameObject.GetComponent<Tower>().spawntime -= 0.1f;
                        score -= 10;
                    }
                    else
                    {
                        print("It Is Max))");
                    }
                }
            }

        }
    //}
    }
}



                   