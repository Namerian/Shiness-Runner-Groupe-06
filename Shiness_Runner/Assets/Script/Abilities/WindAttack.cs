using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WindAttack : MonoBehaviour {

    public GameObject windProjectile;
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
            GameObject _projectile = Instantiate(windProjectile, transform.position + new Vector3(1, 0.75f, 0), transform.rotation) as GameObject;
            _projectile.transform.parent = gameObject.transform;
            _timeStamp = Time.time + coolDownPeriod;
            //cooldownFeedback.value = coolDownPeriod;
            _anim.SetTrigger("PunchToRun");
        }
    }

    void Update()
    {
        //cooldownFeedback.value -= Time.deltaTime;
    }
}
