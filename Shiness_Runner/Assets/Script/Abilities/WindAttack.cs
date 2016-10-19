using UnityEngine;
using System.Collections;

public class WindAttack : MonoBehaviour {

    public GameObject windProjectile;
    public float coolDownPeriod;

    float _timeStamp;

    public void Attack()
    {
        
        if (_timeStamp <= Time.time)
        {
            Instantiate(windProjectile, transform.position + new Vector3(1, 0, 0), transform.rotation);
            _timeStamp = Time.time + coolDownPeriod;
        }
    }
}
