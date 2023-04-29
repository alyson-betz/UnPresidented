using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameLogic Logic;
    public int SpawnSide;
    public double SpawnTime;
    //double SpawnTimeDef = 0.2;
    public GameObject EnemyPreFab;
    public List<GameObject> EnemyMax;
    private Camera cam;
    public double currSpawnTime = 5;
   
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        SpawnSide = Random.Range(0, 2);
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Logic.paused)
        {
            SpawnNewEnemy();
        }
    }

    private void SpawnNewEnemy()
    {
        var EnemyMax = GameObject.FindGameObjectsWithTag("Enemy");
        if (currSpawnTime <= 0 && Logic.GameOverScreen.activeInHierarchy == false && EnemyMax.Length < Logic.EnemyMax)
        {
            //SpawnTime = currSpawnTime;
            SpawnSide = Random.Range(0, 2);

            //cam.ScreenToWorldPoint()
            if (SpawnSide == 0)
            {
                //Instantiate(EnemyPreFab, new Vector3(-12f, Random.Range(-6f, 6f), 0f), Quaternion.identity);
                Instantiate(EnemyPreFab, new Vector3(-6f, 2f, 0f), Quaternion.identity);

            }
            else if (SpawnSide == 1)
            {
                //Instantiate(EnemyPreFab, new Vector3(12f, Random.Range(-6f, 6f), 0f), Quaternion.identity);
                Instantiate(EnemyPreFab, new Vector3(6f, 0f, 0f), Quaternion.identity);

            }
            else if (SpawnSide == 2)
            {
                Instantiate(EnemyPreFab, new Vector3(Random.Range(-12f, 12f), 6f, 0f), Quaternion.identity);

            }
            else if (SpawnSide == 3)
            {
                Instantiate(EnemyPreFab, new Vector3(Random.Range(-12f, 12f), -6f, 0f), Quaternion.identity);

            }


            currSpawnTime = SpawnTime;

        }
        else
        {
            currSpawnTime -= Time.deltaTime;
        }
    }
}

