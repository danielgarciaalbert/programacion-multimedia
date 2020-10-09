// Martians - Daniel García (Enemy class)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private float movementSpeed;
    [SerializeField] Transform enemyShotPrefab;
    private float enemyShotSpeed;

    void Start()
    {
        movementSpeed = 1f;
        enemyShotSpeed = -2;
        StartCoroutine(Shoot());
    }

    void Update()
    {
        transform.Translate(0, movementSpeed * Time.deltaTime, 0);
    }

    IEnumerator Shoot()
    {
        float pause = Random.Range(5.0f, 11.0f);
        yield return new WaitForSeconds(pause);
        Transform shot = Instantiate(enemyShotPrefab,
            transform.position, Quaternion.identity);
        shot.gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector3(enemyShotSpeed, 0, 0);
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<UpperCollider>()
            || other.GetComponent<LowerCollider>())
        {
            transform.position = new Vector3(
                transform.position.x - 0.5f, transform.position.y, 0f);
            movementSpeed = -movementSpeed;
        }
        else if (other.GetComponent<SpeedBoster>())
        {
            movementSpeed += movementSpeed;
        }
    } 
}
