using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightAttack : MonoBehaviour {

    public GameObject lightProjectile;
    public float coolDownPeriod;
    public Slider cooldownFeedback;

    float _timeStamp;

    public void Attack()
    {

        if (_timeStamp <= Time.time)
        {
            GameObject go = Instantiate(lightProjectile, transform.position + new Vector3(1, 0, 0), transform.rotation) as GameObject;
            go.transform.parent = transform;
            _timeStamp = Time.time + coolDownPeriod;
            cooldownFeedback.value = coolDownPeriod;
        }
    }

    void Update()
    {
        cooldownFeedback.value -= Time.deltaTime;
    }

}
