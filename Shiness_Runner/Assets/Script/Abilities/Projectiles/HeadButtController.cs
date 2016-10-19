using UnityEngine;
using System.Collections;

public class HeadButtController : MonoBehaviour {
    
    public float time;
    float _startTime;

    void Start()
    {

        _startTime = Time.time;
    }

    void Update()
    {
        if(_startTime + time <= Time.time)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Enemy_Golem")
        {
            Destroy(col.gameObject);
        }
    }
}
