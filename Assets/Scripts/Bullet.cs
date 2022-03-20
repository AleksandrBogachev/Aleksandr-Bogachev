using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private Transform _target;
    private float _speed;

    public void Init(Transform target, float lifeTime, float speed)


    {
        _target = target;
        _speed = speed;
        Destroy(gameObject, lifeTime);


    }

    void FixedUpdate()
    {
        
        transform.position += transform.forward * _speed * Time.fixedDeltaTime;
    }
}
