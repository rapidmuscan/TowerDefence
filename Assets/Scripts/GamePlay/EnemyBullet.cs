using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int damage = 10;

    public GameObject currtarget;
    public float range;
    public float areaofdamage;
    public LayerMask EnemyLayer;
    public GameObject effect;
    private Vector2 target;

    private void Start()
    {
        currtarget = transform.parent.GetComponent<Tower>().currtarget;
        
        

        
    }

    private void Update()
    {
        if (currtarget != null)
        {
            target = currtarget.transform.position;

            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().health -= damage;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        //if (other.CompareTag("Enemy"))
        //{
        //    Collider2D[] objectstodamage2 = Physics2D.OverlapCircleAll(transform.position, range, EnemyLayer);

        //    for (int i = 0; i < objectstodamage2.Length; i++)
        //    {
        //        objectstodamage2[i].GetComponent<Enemy>().health -= damage;
        //    }
        //    Instantiate(effect, transform.position, Quaternion.identity);
        //    Destroy(gameObject);
        //}


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);

    }
}
