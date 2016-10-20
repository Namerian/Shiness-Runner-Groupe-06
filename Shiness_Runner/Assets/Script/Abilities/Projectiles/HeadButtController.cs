using UnityEngine;
using System.Collections;

public class HeadButtController : MonoBehaviour {
    
    public float time;
    float _startTime;
    GameManager _gm;
    GameObject _player;

    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _startTime = Time.time;
        _player = GameObject.Find("Character3");
    }

    void Update()
    {
        if(_startTime + time <= Time.time)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Enemy_Golem"))
        {
            _gm.AddScore(_gm.enemyGolemScoreValue, _player.GetComponent<HeroController>());
            Destroy(col.gameObject);
        }
    }
}
