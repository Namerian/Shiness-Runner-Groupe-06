using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeadButt : MonoBehaviour {

    public GameObject headButtHitbox;
    public float coolDownPeriod;
    public Slider cooldownFeedback;
    Animator _anim;

    float _timeStamp;

    public void Attack()
    {
        _anim = gameObject.GetComponent<Animator>();
        if (_timeStamp <= Time.time)
        {
            _anim.SetTrigger("RunToPunch");
            GameObject go = Instantiate(headButtHitbox, transform.position + new Vector3(1, 0.75f, 0), transform.rotation) as GameObject;
            go.transform.parent = transform;
            _timeStamp = Time.time + coolDownPeriod;
            cooldownFeedback.value = coolDownPeriod;
            _anim.SetTrigger("PunchToRun");
        }
    }

    void Update()
    {
        cooldownFeedback.value -= Time.deltaTime;
    }
}
