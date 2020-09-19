using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] float velocidad = 2;
    private float velocidadDisparo = 2;
    [SerializeField] Transform prefabDisparo;

    //Solo puede haber un disparo en pantalla (usando variable pública y estática)
    public static bool disparoActivo = false;

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

        if (Input.GetKeyDown("space") && !disparoActivo)
        {
            disparoActivo = true;
            Transform disparo = Instantiate(
                prefabDisparo, transform.position, Quaternion.identity);
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector3(0, velocidadDisparo, 0);
        }
    }   

    //Comprobar colisiones con cualquier otro objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        //TO DO
    }
}
