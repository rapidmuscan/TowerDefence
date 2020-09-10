using UnityEngine;
public class Tower : MonoBehaviour
{
    #region Fields
     private AudioSource _fireSound;
    [SerializeField] private AudioClip _fire;
    public GameObject bullet;
    public float range;
    public int lvl = 1;
    public GameObject currtarget = null;
    
    public float startTimeBtwShots;
    public LayerMask EnemyLayer;
    public Transform spawnpos;
    
    private GameObject bulletshot;
   [SerializeField] private float timeBtwShots;
    public float spawntime;
    private float currtime = 0;
    #endregion
    #region Unity Methods
    private void Start()
    {
        
        transform.GetChild(0).gameObject.SetActive(true);
        _fireSound = GameObject.FindGameObjectWithTag("TowerShotSound").GetComponent<AudioSource>();
    }
    private void Update()
    {
        spawntime = timeBtwShots - (0.094f * lvl);
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
                SoundFx(_fire);
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
    #endregion
    #region CustomMethods
    public void SoundFx(AudioClip _fire)
    {
        _fireSound.PlayOneShot(_fire);
    }
    #endregion
}
