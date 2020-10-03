// Martians - Daniel García (SpawnEnemy class)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;
    private static int maxAmountOfEnemies;
    private static int currentAmountOfEnemies;
    private static bool startingGame;

    void Start()
    {
        StartCoroutine(CreateEnemies());
        maxAmountOfEnemies = 9;
        currentAmountOfEnemies = 0;
        startingGame = true;
    }

    void Update()
    {

    }

    IEnumerator CreateEnemies()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(enemyPrefab, GetComponent<SpawnEnemies>().transform.position, Quaternion.identity);
        if (currentAmountOfEnemies < maxAmountOfEnemies)
            StartCoroutine(CreateEnemies());
        currentAmountOfEnemies++;
        startingGame = false;
    }
    

    public static int GetAmountOfEnemies()
    {
        return currentAmountOfEnemies;
    }

    public static void RemoveEnemy()
    {
        currentAmountOfEnemies--;
    }

    public static bool StartedGame()
    {
        return startingGame;
    }
}
