using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]


public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeofEnemies;
    public float spawnInterval;
}

public class SpawnEnemies : MonoBehaviour
{

    public Wave[] waves;        // show in inspector
    public Transform[] spawnPoints;
 //   public Animator animator;
  //  public Text waveName;


    // what wave?
    private Wave currentWave;           
    private int currentWaveNumber;      // 0 = 1st wave, 1 = 2nd wave, etc
    private float nextSpawnTime;

    private bool canSpawn = true;
  //  private bool canAnimate = false;

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalSmallEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalSmallEnemies.Length == 0  && currentWaveNumber+1 != waves.Length) // && canAnimate)
        {
  //          waveName.text = waves[currentWaveNumber + 1].waveName;
  //          animator.SetTrigger("WaveComplete");
        }

        GameObject[] totalMediumEnemies = GameObject.FindGameObjectsWithTag("Medium alien");
        if (totalMediumEnemies.Length == 0  && currentWaveNumber + 1 != waves.Length) // && canAnimate)
        {
  //          waveName.text = waves[currentWaveNumber + 1].waveName;
 //           animator.SetTrigger("WaveComplete");
        }


        void SpawnNextWave()
        {
            currentWaveNumber++;
            canSpawn = true;
        }

    }

    void SpawnWave()        // take random enemy type and spawnpoint. Spawn enemy
    {
        if (canSpawn && nextSpawnTime < Time.time) 
        {
            GameObject randomEnemy = currentWave.typeofEnemies[Random.Range(0, currentWave.typeofEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.noOfEnemies == 0)   // can only spawn when number of enemies in wave is 0
            {
                canSpawn = false;
             //   canAnimate = true;
            }
        }
    }

}
