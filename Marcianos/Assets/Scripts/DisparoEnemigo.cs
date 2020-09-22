using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    void Start()
    {
        
    }

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
