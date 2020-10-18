using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollider4 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LastText>().SendMessage("TextEnabled");
    }
}
