using UnityEngine;

public class SpawnEnemyPoint : MonoBehaviour
{
    #region Fields
    [SerializeField] private Transform _enemyParent;
    public float spawntime = 1;
    public GameObject Enemy;
    private float currtime = 0;
    int enemiecout = 0;
    private GameObject spawendobj;
    float extrahealth = 0;
    float num = 0;
    #endregion
    #region Unity Methods
    void Update()
    {
        currtime += Time.deltaTime;
        if (currtime > spawntime)
        {
            spawendobj = Instantiate(Enemy, transform.position, Quaternion.identity);
            spawendobj.transform.SetParent(_enemyParent);
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
    #endregion
}
