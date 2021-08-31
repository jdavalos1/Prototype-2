using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float xRange = 10;
    public float zRange = 10;
    public GameObject projectilePrefab;

    public Vector3 projectileOffset;

    private float horizontalInput;
    private float verticalInput;
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LateralMovement();
        ProjectileFiring();
    }
    // Keep track of literal movement
    void LateralMovement()
    {
        // Check if the position has gone out of range on the object
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput +
                            Vector3.forward * Time.deltaTime * speed * verticalInput);
    }
    
    // Keep track of projectile trigger
    void ProjectileFiring()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + projectileOffset, projectilePrefab.transform.rotation);
        }
    }
}
