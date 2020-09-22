using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Nave.puntuacion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LanzarJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
