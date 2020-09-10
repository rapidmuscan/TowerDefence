using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    public float speed;

    public float scorehealth;
    public GameObject effect;

    private Waypoints Wpoints;
    private int waypointIndex;

    public float distancetonextpoint;
    public float distancetoend = 100;

    private void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        scorehealth = health;

        distancetoend = 99;
    }

    private void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);


        Vector3 dir = Wpoints.waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

        distancetonextpoint = Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position);
        float _distancetotheend = 0;
        for (int i = waypointIndex; i < Wpoints.waypoints.Length - 1; i++)
        {
            _distancetotheend += Vector2.Distance(Wpoints.waypoints[waypointIndex].position, Wpoints.waypoints[waypointIndex+1].position);
        }
        _distancetotheend += distancetonextpoint;
        distancetoend = _distancetotheend;

        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            
            if (waypointIndex < Wpoints.waypoints.Length-1)
            {
                waypointIndex++;
            }
            else
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                print(TimeSpan.FromSeconds((int)GameObject.FindGameObjectWithTag("Time").GetComponent<time>().timeinsec).ToString());
            }
        }

         
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().score += (int)(scorehealth*2);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


    }





}
