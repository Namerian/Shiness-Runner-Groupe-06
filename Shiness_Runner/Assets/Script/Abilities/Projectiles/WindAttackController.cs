using UnityEngine;
using System.Collections;

public class WindAttackController : MonoBehaviour {

    public float speed;
    public float range;
    float _startPosition;
    GameManager _gm;
    GameObject _player;

    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _player = GameObject.Find("Character1");
        _startPosition = transform.position.x;
    }

    void Update()
    {
        transform.position += new Vector3(speed/10, 0);
        if (transform.position.x - _startPosition >= range)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Enemy_Essaim"))
        {
            _gm.AddScore(_gm.enemyEssaimScoreValue, _player.GetComponent<HeroController>());
            Destroy(col.gameObject);
        }
        Destroy(gameObject);
    }
}
