using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsText : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {

    }

    public void TextEnabled()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }
}
