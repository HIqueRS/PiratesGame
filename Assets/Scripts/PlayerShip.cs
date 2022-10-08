using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ships
{
    [SerializeField]
    private InputSchema _input;

    private void Start()
    {
        _angle = 0;
        _direction = Vector2.up;
        _health = _maxHealth;

        _sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        RotationInput();

        if(_input.InputForward())
        {
            MoveForward();
        }

        if(_input.InputFire1())
        {
            ShootForward();//ou fazer só shoot depois?
        }
    }

    private void RotationInput()
    {
        if (_input.InputRotateLeft())
        {
            _angle--;
        }

        if (_input.InputRotateRight())
        {
            _angle++;
        }
    }
}
