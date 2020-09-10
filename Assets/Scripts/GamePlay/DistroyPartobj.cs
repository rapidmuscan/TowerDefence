using UnityEngine;

public class DistroyPartobj : MonoBehaviour
{
    #region Fields
    public float timelive = 0;
    public float currtime = 0;
    #endregion
    #region Unity Methods
    void Update()
    {
        currtime += Time.deltaTime;
        if (currtime > timelive)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    #region Custom Methods
    #endregion


}
