using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject VoodoDude;
    public float rndSpawnRange = 2;
    public float DistForActiveSpawn;
    [HideInInspector]
    public Transform Target;

    List<GameObject> enemies;

    //COUNTERS
    public float TimeOfSpawnDefault = 15f;
    float timeOfSpawnCounter;

    void Start()
    {
        enemies = new List<GameObject>();

        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(VoodoDude, transform);
            Vector3 rnd = new Vector3(Random.Range(-rndSpawnRange, rndSpawnRange), 0, Random.Range(-rndSpawnRange, rndSpawnRange));
            go.transform.position = transform.position + rnd;
            EnemyBehaviour enemyBehaviour = go.GetComponent<EnemyBehaviour>();
            enemyBehaviour.Player = Target;
            enemyBehaviour.InitialPosition = go.transform.position;
            go.SetActive(false);
            enemies.Add(go);
        }
        timeOfSpawnCounter = Random.Range(0, TimeOfSpawnDefault);
        Target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //if (Vector3.Distance(Target.position, transform.position) <= DistForActiveSpawn)
        //    SetState();
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        earlyGameState();
    }


    void startGameState()
    {
        timeOfSpawnCounter += Time.deltaTime;
        if (timeOfSpawnCounter >= TimeOfSpawnDefault)
        {
            timeOfSpawnCounter = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].activeSelf)
                {
                    enemies[i].SetActive(true);
                    break;
                }
            }
        }
    }

    void earlyGameState()
    {
        timeOfSpawnCounter += Time.deltaTime;
        if (timeOfSpawnCounter >= TimeOfSpawnDefault)
        {
            timeOfSpawnCounter = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].activeSelf)
                {
                    enemies[i].SetActive(true);
                    enemies[i].GetComponent<EnemyBehaviour>().FixNavmesh();
                    break;
                }
            }
        }
    }

    void midGameState()
    {
        timeOfSpawnCounter += Time.deltaTime;
        if (timeOfSpawnCounter >= TimeOfSpawnDefault)
        {
            timeOfSpawnCounter = 0;
            int index = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].activeSelf)
                {
                    enemies[i].SetActive(true);
                    enemies[i].GetComponent<EnemyBehaviour>().FixNavmesh();
                    index++;
                    if(index == 2)
                        break;
                }
            }
        }
    }

    void lateGameState()
    {
        timeOfSpawnCounter += Time.deltaTime;
        if (timeOfSpawnCounter >= TimeOfSpawnDefault *0.5f)
        {
            timeOfSpawnCounter = 0;
            int index = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].activeSelf)
                {
                    enemies[i].SetActive(true);
                    enemies[i].GetComponent<EnemyBehaviour>().FixNavmesh();

                    index++;
                    if (index == 2)
                        break;
                }
            }
        }
    }
}
