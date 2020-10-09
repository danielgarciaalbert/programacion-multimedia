using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody body;
    float movementVelocity = 250f;
    float rotationVelocity = 2.5f;
    [SerializeField] Light lantern;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        lantern = GetComponent<Light>();
    }

    void Update()
    {
        /*
        float fordwardAndBackwardMovement = Input.GetAxis("Vertical") 
            * velocity * Time.deltaTime;
        float leftAndRightMovement = Input.GetAxis("Horizontal") 
            * velocity * Time.deltaTime;
        body.velocity = new Vector3(
            fordwardAndBackwardMovement, 0, leftAndRightMovement);
        */

        float fordwardAndBackwardMovement = Input.GetAxis("Vertical")
            * movementVelocity * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal")
            * rotationVelocity * Time.deltaTime;
        transform.RotateAround(Vector3.up, rotation);
        transform.position +=
            transform.forward * Time.deltaTime * fordwardAndBackwardMovement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lantern.enabled = !lantern.enabled;
        }
    }

    public void TakeCoin()
    {
        Debug.Log("Coin!!!");
    }
}
