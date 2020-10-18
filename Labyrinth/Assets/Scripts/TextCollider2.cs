using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollider2 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<ControlsText>().SendMessage("TextEnabled");
    }
}
