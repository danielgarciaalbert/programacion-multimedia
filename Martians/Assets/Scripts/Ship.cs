// Martians - Daniel García (Ship class)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Text LivesText;
    public Text ScoreText;
    [SerializeField] float movementSpeed = 2f;
    private float shotSpeed = 5f;
    private static int lives;
    private static int score;
    private static bool activeShot;
    [SerializeField] Transform shotPrefab;

    void Start()
    {
        lives = 3;
        score = 0;
        activeShot = false;
    }

    void Update()
    {
        float movement = Input.GetAxis("Vertical");
        transform.Translate(0, movement * movementSpeed * Time.deltaTime, 0);

        //Upper aand lower limitation of ship movement
        if (transform.position.y < -2.5f)
        {
            transform.position = new Vector3(
                transform.position.x, -2.5f, transform.position.z);
        }
        else if (transform.position.y > 2.5f)
        {
            transform.position = new Vector3(
                transform.position.x, 2.5f, transform.position.z);
        }

        if (Input.GetKeyDown("space") && !ShotStatus())
        {
            TurnOnActiveShot();
            Transform shot = Instantiate(
                shotPrefab, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity =
                new Vector3(shotSpeed, 0, 0);
            GetComponent<AudioSource>().Play();
        }

        ScoreText.text = "Score: " + score;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyShot")
        {
            GetComponent<AudioSource>().Play();
            lives -= 1;
            LivesText.text = "Lives: " + lives;

            StartCoroutine(ChangeColor());

            if (lives <= 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
        else if (other.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public static void AddScore()
    {
        score += 1;
    }

    public static void RemoveLife()
    {
        lives -= 1;
    }

    public static int GetLives()
    {
        return lives;
    }

    public static void TurnOnActiveShot()
    {
        activeShot = true;
    }

    public static void TurnOffActiveShot()
    {
        activeShot = false;
    }

    public static bool ShotStatus()
    {
        return activeShot;
    }
}
