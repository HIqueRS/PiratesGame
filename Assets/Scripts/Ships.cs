using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour
{

    protected float _angle;
    protected Vector2 _direction;
    [SerializeField]
    protected float _rotSpeed;
    [SerializeField]
    protected float _movSpeed;
    [SerializeField]
    public int _maxHealth;
    [HideInInspector]
    public int _health;
    [SerializeField]
    protected HealthBar _healthBar;

    [SerializeField]
    protected Sprite[] _states;

    [SerializeField]
    protected SpriteRenderer _sprite;

    [SerializeField]
    protected GameObject _bullet;

    private void FixedUpdate()
    {
        Rotation();
    }

    private void Rotation()
    {
        Quaternion rotation = Quaternion.AngleAxis(-_angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotSpeed * Time.deltaTime);
    }

    protected void MoveForward()
    {

        Vector3 position = transform.position;
        transform.position = Vector2.MoveTowards(position, position + transform.TransformDirection(_direction), _movSpeed * Time.deltaTime);
    }

    public void ChangeHealth(int amount)
    {
        _health += amount;

        _healthBar.AtualizeHealth(_health);

        ChangeSprite();
    }

    public void ChangeMaxHealth(int amount)
    {
        _maxHealth += amount;

        _healthBar.AtualizeMaxHealth(_maxHealth);

        ChangeSprite();

    }

    void ChangeSprite()
    {
        if(_health < _maxHealth/3)
        {
            _sprite.sprite = _states[1];
        }
        else if(_health < (_maxHealth/3)*2)
        {
            _sprite.sprite = _states[0];
        }

    }

    public void ShootForward()
    {
        GameObject.Instantiate(_bullet,transform.position + (transform.TransformDirection(_direction)*0.6f),Quaternion.identity);
    }
}
