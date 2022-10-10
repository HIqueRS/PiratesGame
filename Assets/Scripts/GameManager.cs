using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Configs _config;

    private float _timePassed;

    // Start is called before the first frame update
    void Start()
    {
        _timePassed = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!_config.EveryoneisDead())
        {
            if (_timePassed > 1 / _config.GetSpawnRate())
            {
                Spawn();
                _timePassed = 0;
            }
        }
        _timePassed += Time.deltaTime;
    }

    void Spawn()
    {
        Vector3 position;
        int id;

        position =  (Random.insideUnitCircle.normalized * 14.5f);

        position = position + transform.position;

        id = Random.Range(0, _enemies.Length);

        position = new Vector3(position.x, position.y, -20);

        GameObject.Instantiate(_enemies[id], position, Quaternion.identity);

    }

    void SpawnPlayers()
    {
        GameObject.Instantiate(_player);
    }

}
