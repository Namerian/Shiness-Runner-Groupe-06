using UnityEngine;
using System.Collections;

public class HeadButt : MonoBehaviour {

    public GameObject headButtHitbox;
    public float coolDownPeriod;

    float _timeStamp;

    public void Attack()
    {

        if (_timeStamp <= Time.time)
        {
            GameObject go = Instantiate(headButtHitbox, transform.position + new Vector3(1, 0, 0), transform.rotation) as GameObject;
            go.transform.parent = transform;
            _timeStamp = Time.time + coolDownPeriod;
        }
    }
}
