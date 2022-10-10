using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Ships
{
    private GameObject[] _target;
    private int _targetID;
    private float _dist;
    private float _distAux;

    

    // Start is called before the first frame update
    void Start()
    {
        _direction = Vector2.up;


        _target = GameObject.FindGameObjectsWithTag("Player");

        _targetID = Random.Range(0, _target.Length);

        _health = _maxHealth;

        _sprite = GetComponent<SpriteRenderer>();

        _died = false;

        _isPlayer = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!_configs.EveryoneisDead())
        {
            if (_health > 0)
            {
                DefineClosestTarget();

                SetAngleToTarget();

                MoveForward();
            }
        }

        

        

    }

    void DefineClosestTarget()
    {
        _dist = float.MaxValue;

        for (int i = 0; i < _target.Length; i++)
        {
            if (_target[i] != null)
            {
                _distAux = Vector2.Distance(transform.position, _target[i].transform.position);
                if (_distAux < _dist)
                {
                    _dist = _distAux;
                    _targetID = i;
                }
            }
            
        }
    }

    void SetAngleToTarget()
    {
        if(_target[_targetID] != null)
        {
            Vector2 _targetDir = _target[_targetID].transform.position - transform.position;

            _angle = Mathf.Atan2(_targetDir.x, _targetDir.y) * Mathf.Rad2Deg;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collided;

        collided = collision.gameObject;

        if (collided.CompareTag("Player") )
        {
            collided.GetComponent<Ships>().ChangeHealth(-_damage);

            GameObject.Destroy(transform.parent.gameObject, 0.1f);
        }

        if(collided.CompareTag("Obstacles"))
        {
            GameObject.Destroy(transform.parent.gameObject,0.2f);
            Die(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collided;

        collided = collision.gameObject;

        if (collided.CompareTag("Obstacles"))
        {
            GameObject.Destroy(transform.parent.gameObject, 0.2f);
            Die(false);
        }
    }
}
