using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    float velocidadX = 1;
    //float velocidadY = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, 
            0, 0);

        if (transform.position.x < -4 || transform.position.x > 4)
        {
            transform.position = new Vector3(
                transform.position.x, transform.position.y - 0.5f, 0f);
            velocidadX = -velocidadX;
        }

        /* if (transform.position.y < -2.5 || transform.position.y > 2.5)
            velocidadY = -velocidadY; */
    }
}