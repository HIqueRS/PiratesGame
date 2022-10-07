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
        _direction = -Vector2.up;
    }


    private void Update()
    {
        RotationInput();

        if(_input.InputForward())
        {
            MoveForward();
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
