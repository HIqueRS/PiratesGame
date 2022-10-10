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

        _configs.ResetPoint();

        _died = false;

        _isPlayer = true;
    }


    private void Update()
    {
        if(_health > 0)
        {
            RotationInput();

            if (_input.InputForward())
            {
                MoveForward();
            }

            if (_input.InputFire1())
            {
                if (_timeRate > 1 / _fireRate)
                {
                    ShootForward(_damage, _shootRange);
                }

            }

            if (_input.InputFire2())
            {
                if (_timeRate > 1 / _fireRate)
                {
                    TripleSideShoot(); //maybe mudar
                }
            }
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

    private void TripleSideShoot()
    {

        Vector3 position, direction, bulletsDist;

        for (int i = 0; i < 6; i++)
        {
            if(i < 3)
            {
                direction = transform.TransformDirection(Vector2.left);

                bulletsDist = transform.TransformDirection((i - 1) * Vector3.up) * 0.6f;

                position = transform.position + (direction * 0.6f) + bulletsDist;

            }
            else
            {
                direction = transform.TransformDirection(Vector2.right);

                bulletsDist = transform.TransformDirection((i - 4) * Vector3.up) * 0.6f;

                position = transform.position + (direction * 0.6f) + bulletsDist;
                
            }


            InstantiateBullet(position, direction,_damage,_shootRange);
        }
    }
}
