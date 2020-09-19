using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] float velocidad = 2;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);

        //Estableciendo límites laterales para la nave
        if (transform.position.x < -4.25)
        {
            transform.position = new Vector3(   
                -4.25f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 4.25 )
        {
            transform.position = new Vector3(
                4.25f, transform.position.y, transform.position.z);
        }
    }   

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Golpeado");
    }
}
