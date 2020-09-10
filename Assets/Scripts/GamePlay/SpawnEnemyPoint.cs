using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyPoint : MonoBehaviour
{
    public float spawntime = 1;
    public GameObject Enemy;
    private float currtime = 0;
    int enemiecout = 0;
    private GameObject spawendobj;
    float extrahealth = 0;
    float num = 0;
    void Update()
    {
        currtime += Time.deltaTime;
        if (currtime > spawntime)
        {
            spawendobj = Instantiate(Enemy, transform.position, Quaternion.identity);
            spawendobj.GetComponent<Enemy>().health += extrahealth;
            spawendobj.name = spawendobj.name + num;

            num++;
            currtime = 0;
            enemiecout++;
        }

        if (enemiecout > 5)
        {
            extrahealth += 300;
            enemiecout = 0;
        }
    }
}
