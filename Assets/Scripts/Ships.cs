using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour
{

    private float _angle;

    private void Start()
    {
        _angle = 0;
    }

    
    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _angle--;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _angle++;
        }
    }


    private void FixedUpdate()
    {
        Rotation();
    }


    private void Rotation()
    {
        Quaternion rotation = Quaternion.AngleAxis(-_angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
    }
}
