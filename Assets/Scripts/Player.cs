using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public GameObject shieldPrefab;
    public Transform spawnPosition;


    private int level = 1;
    private bool _isSpawnShield;
    
  
    private Vector3 _direction;
    public float speed = 2f;
    private bool _isSprint;

   
    void Start()

    {
        
        var point1 = new Vector3 (1f, 5f, 1462f);
        var point2 = new Vector3 (1f, 5f, 1462f);
        var dist = Vector3.Distance(point1, point2);
        Debug.Log(dist);
        Debug.Log(Vector3.one.magnitude);




    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            _isSpawnShield = true;

        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _isSprint = Input.GetButton("Sprint");

        
        

    }

    private void FixedUpdate()
    {
        if (_isSpawnShield)
        {
            _isSpawnShield = false;
            SpawnShield();


        }
        Move(Time.fixedDeltaTime);

    }




     private void SpawnShield()
    {
        var shieldObj = Instantiate(shieldPrefab, spawnPosition.position, spawnPosition.rotation);
        var shield = shieldObj.GetComponent<shield>();
        shield.Init(10 * level);

    }

    private void Move(float delta)
    {
        transform.position += _direction.normalized * (_isSprint ? speed * 2 : speed)  * delta;
    }




}
