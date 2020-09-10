using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Tower : MonoBehaviour
{

    public GameObject bullet;
    public float range;
    public int lvl = 1;
    public GameObject currtarget = null;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public LayerMask EnemyLayer;
    public Transform spawnpos;
    
    private GameObject bulletshot;

    public float spawntime = 1;
    private float currtime = 0;
    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private void Update()
    {
        spawntime = 1 - (0.094f * lvl);
        if (currtarget == null) {
            
            Collider2D[] search = Physics2D.OverlapCircleAll(transform.position, range, EnemyLayer);

            float minimumvalue = 100000;
            GameObject checker = null;
            for (int i = 0; i < search.Length; i++)
            {
                if(search[i].gameObject.GetComponent<Enemy>().distancetoend < minimumvalue)
                {
                    minimumvalue = search[i].gameObject.GetComponent<Enemy>().distancetoend;
                    checker = search[i].gameObject;
                }

                //Enemies[i] = search[i].gameObject;
                //currtarget = search[i].gameObject;
                //search[i].GetComponent<Enemy>().health -= 1;
            }
            currtarget = checker; 
            minimumvalue = float.MaxValue; 
            
        }
        else
        {

            currtime += Time.deltaTime;
            if (currtime > spawntime)
            {
                bulletshot = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletshot.transform.SetParent(transform);
                bulletshot.GetComponent<EnemyBullet>().damage = 10 + ((lvl - 1) * 10);
                currtime = 0;
            }
        }
        if (currtarget != null)
        {

            if (Vector2.Distance(transform.position, currtarget.transform.position) > range)
            {

                currtarget = null;
            }
        }


       
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);

    }
}
