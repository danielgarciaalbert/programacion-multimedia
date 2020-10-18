using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollider3 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AdviceText>().SendMessage("TextEnabled");
    }
}
