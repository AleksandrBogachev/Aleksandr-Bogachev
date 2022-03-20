using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPosition;


    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();

            }

        }
    }

    private void Fire()
    {
        var shieldObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
        var shield = shieldObj.GetComponent<Bullet>();
        shield.Init(_player.transform, 30 , 1);

    }
}
