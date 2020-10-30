using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
    private float movementSpeed = 5;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(0, 0, movementSpeed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 strengthJump = new Vector3(0, 5, 0);
            rigidBody.AddForce(strengthJump, ForceMode.Impulse);
            // rigidBody.MoveRotation(new Quaternion())
        }
    }
}



