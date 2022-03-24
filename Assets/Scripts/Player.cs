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
    public float gravity = 0;
    private bool _isSprint;

    private CharacterController _charController;





    void Start()

    {
        _charController = GetComponent<CharacterController>();

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

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
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
