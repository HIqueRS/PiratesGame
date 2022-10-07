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
}
