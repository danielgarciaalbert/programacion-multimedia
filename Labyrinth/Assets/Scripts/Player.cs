using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody body;
    float movementVelocity = 750f;
    float rotationVelocity = 2.5f;
    private AudioSource step;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        step = GetComponent<AudioSource>();
    }

    void Update()
    {
        float fordwardAndBackwardMovement = Input.GetAxis("Vertical")
            * movementVelocity * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal")
            * rotationVelocity * Time.deltaTime;
        transform.RotateAround(Vector3.up, rotation);
        transform.position +=
            transform.forward * Time.deltaTime * fordwardAndBackwardMovement;

        if (fordwardAndBackwardMovement != 0 || rotation != 0)
        {
            if (!step.isPlaying)
                step.Play();
        }
        else
        {
            step.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
        }
    }
}
