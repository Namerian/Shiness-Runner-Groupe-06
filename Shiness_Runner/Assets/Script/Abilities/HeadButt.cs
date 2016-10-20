using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeadButt : MonoBehaviour {

    public GameObject headButtHitbox;
    public float coolDownPeriod;
    public Slider cooldownFeedback;

    float _timeStamp;

    public void Attack()
    {

        if (_timeStamp <= Time.time)
        {
            GameObject go = Instantiate(headButtHitbox, transform.position + new Vector3(1, 0.75f, 0), transform.rotation) as GameObject;
            go.transform.parent = transform;
            _timeStamp = Time.time + coolDownPeriod;
            //cooldownFeedback.value = coolDownPeriod;
        }
    }

    void Update()
    {
        //cooldownFeedback.value -= Time.deltaTime;
    }
}
