using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera camara;
    float distanciaMaxima = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Disparando");
            RaycastHit impacto;
            bool impactado = Physics.Raycast(camara.transform.position,
                camara.transform.forward,
                out impacto,
                distanciaMaxima);

            if (impactado)
            {
                Debug.Log("Disparo impactado");
                if (impacto.collider.CompareTag("Enemigo"))
                {
                    Debug.Log("Disparo acertado");
                }
            }
        }
    }
}
