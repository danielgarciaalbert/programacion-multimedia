// Martians - Daniel García (ShipShot class)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipShot : MonoBehaviour
{
    [SerializeField] Transform enemyParticlesPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<RightCollider>())
        {
            Destroy(gameObject);
            Ship.TurnOffActiveShot();
        }
        else if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Transform particles = Instantiate(enemyParticlesPrefab, 
                other.transform.position, Quaternion.identity);
            Destroy(particles.gameObject, 1f);
            Ship.TurnOffActiveShot();
            Ship.AddScore();
            SpawnEnemies.RemoveEnemy();

            if (SpawnEnemies.GetAmountOfEnemies() == 0 
                && !SpawnEnemies.StartedGame())
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
