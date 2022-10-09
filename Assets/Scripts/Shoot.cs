using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _range;
    [SerializeField]
    private int _damage;
    private Vector2 _direction;

    private Vector2 _initialPosition;

    [SerializeField]
    private Animator _anim;

    private bool _isDead;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _isDead = false;

        transform.position = new Vector3(transform.position.x, transform.position.y, -2);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsInRange())
        {
            if(!_isDead)
            MoveForward();
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
        
    }

    void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.TransformDirection(_direction), _speed * Time.deltaTime);
    }

    bool IsInRange()
    {
        if(Vector2.Distance(transform.position,_initialPosition) > _range)
        {
            return false;
        }

        return true;
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    public void SetVelocity(float vel)
    {
        _speed = vel;
    }

    public void SetRange(float range)
    {
        _range = range;
    }

    public float GetRange()
    {
        return _range;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject GO;

        GO = collision.gameObject;

        if(GO.CompareTag("Player") || GO.CompareTag("Enemy"))
        {
            GO.GetComponent<Ships>().ChangeHealth(-_damage);

            _anim.SetTrigger("Die");

            _isDead = true;
            GameObject.Destroy(this.gameObject,0.5f);
        }
    }
}
