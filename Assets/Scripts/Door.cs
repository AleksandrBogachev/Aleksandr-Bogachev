using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _rotatePoint;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _rotatePoint.Rotate(Vector3.up, 90);
        }

    }
}
