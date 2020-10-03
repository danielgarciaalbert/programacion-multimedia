// Martians - Daniel García (EnemyShot class)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<LeftCollider>())
            Destroy(gameObject);
        else if (other.tag == "Ship")
        {
            Destroy(gameObject);
        }
    }
}
