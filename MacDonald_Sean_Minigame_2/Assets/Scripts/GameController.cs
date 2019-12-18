using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public GameObject[] enemyPrefabs;


    void Start()
    {
        // spawns inital wave of enemies
        StartCoroutine(SpawnWave(2, 2, new float[] { -2, 2 }, new int[] {0, 0}));
        StartCoroutine(SpawnWave(3, 2, new float[] { 0, 3 }, new int[] { 0, 1 }));
        StartCoroutine(SpawnWave(8, 5, new float[] { 0, 3, -3, 2, -2 }, new int[] { 0, 1, 1, 1, 0 }));
        StartCoroutine(SpawnWave(14, 5, new float[] { 0, 3, -3, 2, -2 }, new int[] { 0, 1, 0, 1, 0 }));
        StartCoroutine(SpawnWave(25, 5, new float[] { 4, 3, -3, 2, -4 }, new int[] { 0, 1, 1, 1, 1 }));
        StartCoroutine(SpawnWave(36, 5, new float[] { 4, 3, -3, 2, -4 }, new int[] { 0, 1, 1, 1, 1 }));
        StartCoroutine(SpawnWave(50, 1, new float[] { 0 }, new int[] { 2 }));


    }

    // will spawn a specified num of enemies after a delay, num of elements in numEnemies and spawnPositions and enemyTypes must be equal to fully work
    IEnumerator SpawnWave(float startDelay, int numEnemies, float[] spawnPositions, int[] enemyTypes)
    {
        yield return new WaitForSeconds(startDelay);
        for(int i = 0; i < numEnemies && i < spawnPositions.Length && i < enemyTypes.Length; i++)
        {
            Vector2 spawnPos;
            if (enemyTypes[i] == 2)
                spawnPos = new Vector2(spawnPositions[i], 9);
            else
                spawnPos = new Vector2(spawnPositions[i], 6);
            Instantiate(enemyPrefabs[enemyTypes[i]], spawnPos, Quaternion.identity);
        }



    }





    //will spawn specified num of enemy waves after time delays
    





}
