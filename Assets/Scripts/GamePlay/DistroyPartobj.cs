using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyPartobj : MonoBehaviour
{
    public float timelive = 0;
    public float currtime = 0;
    void Update()
    {
        currtime += Time.deltaTime;
        if (currtime > timelive)
        {
            Destroy(gameObject);
        }
    }
}
