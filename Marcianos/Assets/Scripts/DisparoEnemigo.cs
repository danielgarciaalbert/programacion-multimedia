﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ColliderInferior>())
        {
            Destroy(gameObject);
        }

        if (other.tag == "Nave")
        {
            Destroy(gameObject);
        }
    }
}
