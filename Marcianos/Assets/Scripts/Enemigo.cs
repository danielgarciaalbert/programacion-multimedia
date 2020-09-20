using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    float velocidadX = 1;
    //float velocidadY = 0;
    private float velocidadDisparoEnemigo = -2;
    [SerializeField] Transform prefabDisparoEnemigo;

    void Start()
    {
        StartCoroutine(Disparar());
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

    IEnumerator Disparar()
    {
        float pausa = Random.Range(5.0f, 11.0f);
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabDisparoEnemigo,
            transform.position, Quaternion.identity);
        disparo.gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector3(0, velocidadDisparoEnemigo, 0);
        StartCoroutine(Disparar());
    }
}