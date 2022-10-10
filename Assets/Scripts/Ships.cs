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

    protected float _bulletInitPos;

    [SerializeField]
    protected int _damage;

    [SerializeField]
    protected float _fireRate;

    protected float _timeRate;

    [SerializeField]
    protected float _shootRange;

    [SerializeField]
    protected Animator _animator;

    [SerializeField]
    protected int _point;

    [SerializeField]
    protected Configs _configs;

    protected bool _died;

    protected bool _isPlayer;

    private void FixedUpdate()
    {
        Rotation();

        _timeRate += Time.deltaTime;
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
        if(_health <= 0)
        {
            Die();
        }
        else if(_health < _maxHealth/3)
        {
            _sprite.sprite = _states[1];
        }
        else if(_health < (_maxHealth/3)*2)
        {
            _sprite.sprite = _states[0];
        }


    }

    void Die()
    {
        if(!_died)
        {
            _animator.SetTrigger("Die");

            _configs.AddPoints(_point);

            Destroy(transform.parent.gameObject, 1f);

            if(_isPlayer)
            {
                _configs.AddDeath();
            }

            _died = true;
        }
        
    }

    public void ShootForward(int damage, float range)
    {
        Vector3 position, direction;

        direction = transform.TransformDirection(_direction);
        position = transform.position + (direction * 0.6f);

        InstantiateBullet(position, direction, damage, range);

        
    }

    public void InstantiateBullet(Vector2 position ,Vector2 direction, int damage,float range)
    {
        GameObject bullet;
        Shoot shoot;
        bullet = GameObject.Instantiate(_bullet, new Vector3(position.x, position.y, -2), Quaternion.identity) ;

        shoot = bullet.GetComponent<Shoot>();

        shoot.SetDirection(direction);
        shoot.SetDamage(damage);
        shoot.SetRange(range);



        _timeRate = 0;
    }
}
