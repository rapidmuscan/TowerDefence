using System;
using UnityEngine;
using EZCameraShake;

public class Enemy : MonoBehaviour
{
    #region Fields
    private AudioSource _deathSound;
    [SerializeField] private AudioClip _deathFx;

    public float health = 1;
    public float speed;
    public int particleDestroyTime;

    public float scorehealth;
     private Transform _parentObject;
    public GameObject dieEffect;
    public GameObject hitEffect;
    public GameObject coinEffect;
    public int hitDestroyTime;

    private Waypoints Wpoints;
    private int waypointIndex;

    public float distancetonextpoint;
    public float distancetoend = 100;
    #endregion
    #region Unity Methods
    private void Start()
    {
        _deathSound = GameObject.FindGameObjectWithTag("EnemyDeathSound").GetComponent<AudioSource>();
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        scorehealth = health;
        distancetoend = 99;
        _parentObject = GameObject.FindGameObjectWithTag("Particles").GetComponent<Transform>();
    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);


        Vector3 dir = Wpoints.waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        distancetonextpoint = Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position);
        float _distancetotheend = 0;
        for (int i = waypointIndex; i < Wpoints.waypoints.Length - 1; i++)
        {
            _distancetotheend += Vector2.Distance(Wpoints.waypoints[waypointIndex].position, Wpoints.waypoints[waypointIndex + 1].position);
        }
        _distancetotheend += distancetonextpoint;
        distancetoend = _distancetotheend;

        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {

            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
              //  Instantiate(dieEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                print(TimeSpan.FromSeconds((int)GameObject.FindGameObjectWithTag("Time").GetComponent<time>().timeinsec).ToString());
            }
        }


        if (health <= 0)
        {

            SoundFx(_deathFx);

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().score += (int)(scorehealth * 2);
           var _dieEffect = Instantiate(dieEffect, transform.position, Quaternion.identity);

            _dieEffect.transform.SetParent(_parentObject);
            Destroy(_dieEffect, particleDestroyTime);

            var _coinEffect = Instantiate(coinEffect, transform.position, Quaternion.identity);
            _coinEffect.transform.SetParent(_parentObject);

            Destroy(_coinEffect, particleDestroyTime);
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (health <= 0)
            {
                CameraShaker.Instance.ShakeOnce(2f, 2f, 0.5f, 0.5f);
            }
           var _hitEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            _hitEffect.transform.SetParent(_parentObject);
            Destroy(_hitEffect, hitDestroyTime);
        }
    }



    #endregion
    #region Custom Methods
    public void SoundFx(AudioClip _fire)
    {
        _deathSound.PlayOneShot(_fire);
    }
    #endregion
}
