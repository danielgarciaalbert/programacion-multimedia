using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] Transform prefabParticulas;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Forma que encontré por internet de comprobar qué tipo de objeto es
        if (other.gameObject.GetComponent<ColliderSuperior>())
        {
             Destroy(gameObject);
        }

        //Forma de los apuntes de comprobar qué tipo de objeto es
        if (other.tag == "Enemigo")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Transform particulas = Instantiate(
                prefabParticulas, other.transform.position, Quaternion.identity);
            Destroy(particulas.gameObject, 1f);
        }
    }
}
