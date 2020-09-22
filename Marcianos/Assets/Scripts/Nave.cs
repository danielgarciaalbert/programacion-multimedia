using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nave : MonoBehaviour
{
    [SerializeField] float velocidad = 2;
    private float velocidadDisparo = 2;
    [SerializeField] Transform prefabDisparo;
    private int vidas = 3;

    public Text textoPuntuacion;
    public Text textoVidas;

    //Falta hacer este atributo "privado" y hacer pública una función que lo modifique
    public static int puntuacion = 0;

    //Solo puede haber un disparo en pantalla (usando variable pública y estática)
    public static bool disparoActivo = false;

    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);

        //Estableciendo límites laterales para la nave
        
        if (transform.position.x < -4.30f)
        {
            transform.position = new Vector3(
                -4.30f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 4.30f)
        {
            transform.position = new Vector3(
                4.30f, transform.position.y, transform.position.z);
        }
        

        if (Input.GetKeyDown("space") && !disparoActivo)
        {
            disparoActivo = true;
            Transform disparo = Instantiate(
                prefabDisparo, transform.position, Quaternion.identity);
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector3(0, velocidadDisparo, 0);
            GetComponent<AudioSource>().Play();
        }

        textoPuntuacion.text = "Puntuación: " + puntuacion;
    }   

    //Comprobar colisiones con cualquier otro objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DisparoEnemigo")
        {
            vidas -= 1;
            textoVidas.text = "Vidas: " + vidas;

            StartCoroutine(CambiarColor());

            if (vidas <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private void MostrarGolpeANave()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    IEnumerator CambiarColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public static void SumarPuntuacion()
    {
        puntuacion += 1;
    }
}
