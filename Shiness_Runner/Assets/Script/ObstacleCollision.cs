using UnityEngine;
using System.Collections;

public class ObstacleCollision : MonoBehaviour {

    Animator _anim;
    Rigidbody _rb;
    GameManager _gm;

    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && tag == "Brawl mode obstacles")
        {
            _anim = col.gameObject.GetComponent<Animator>();
            _rb = col.gameObject.GetComponent<Rigidbody>();
            if (_rb.velocity.x == 0)
            {
                _anim.SetTrigger("RunToHit");
                _rb.velocity -= new Vector3(2, 1, 0);
                _gm.Extase -= 5;
                _gm.uicanvas.GetComponent<UI>().HitShake(col.gameObject.name);
                _anim.SetTrigger("HitToRun");
            }
        }else
        if(col.gameObject.tag == "Player" && tag == "Extaz mode obstacles")
        {
            if(name.Contains("Enemy"))
            {
                if (name.Contains("Bat"))
                {
                    _gm.AddScore(_gm.enemyBatScoreValue, col.gameObject.GetComponent<HeroController>());
                    Destroy(gameObject);
                }
                else
                if (name.Contains("Golem"))
                {
                    _gm.AddScore(_gm.enemyGolemScoreValue, col.gameObject.GetComponent<HeroController>());
                    Destroy(gameObject);
                }
                else
                if (name.Contains("Essaim"))
                {
                    _gm.AddScore(_gm.enemyEssaimScoreValue, col.gameObject.GetComponent<HeroController>());
                    Destroy(gameObject);
                }
            }else
            {
                _anim.SetTrigger("RunToHit");
                _gm.PlayerDied(col.gameObject.GetComponent<HeroController>());
                _anim.SetTrigger("HitToRun");
            }
        }
    }
}
