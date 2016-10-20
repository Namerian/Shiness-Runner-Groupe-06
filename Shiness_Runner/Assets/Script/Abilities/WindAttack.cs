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
            GameObject _projectile = Instantiate(windProjectile, transform.position + new Vector3(1, 0, 0), transform.rotation) as GameObject;
            _projectile.transform.parent = gameObject.transform;
            _timeStamp = Time.time + coolDownPeriod;
        }
    }
}
