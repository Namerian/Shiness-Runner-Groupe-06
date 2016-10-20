using UnityEngine;
using System.Collections;

public class LightAttackController : MonoBehaviour {

    public float speed;
    public float range;
    float _startPosition;
    float _yStart;
    float _zStart;
    GameManager _gm;
    GameObject _player;

    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _player = GameObject.Find("Character2");
        _startPosition = transform.position.x;
        _yStart = transform.position.y;
        _zStart = transform.position.z;
    }

    void Update()
    {
        transform.position += new Vector3(speed / 10, 0);
        if (transform.position.y != _yStart || transform.position.z != _zStart)
            transform.position = new Vector3(transform.position.x, _yStart, _zStart);
        if (transform.position.x - _startPosition >= range)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Enemy_Bat"))
        {
            _gm.AddScore(_gm.enemyBatScoreValue, _player.GetComponent<HeroController>());
            Destroy(col.gameObject);
        }
        Destroy(gameObject);
    }
}
