using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemSpawner : MonoBehaviour
{
    public GameObject Item;

    public float SpawnCounterDefault;
    float spawnCounter;

    [HideInInspector]
    public List<Transform> Spawner;
    [HideInInspector]
    public bool CanSpawn;

    public bool IsJustOne;
    bool canSpawnOthers;
    private void Start()
    {
        CanSpawn = false;
        canSpawnOthers = true;
        spawnCounter = SpawnCounterDefault;

        Spawner = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Spawner.Add(transform.GetChild(i));
        }

        SpawnItem();
    }

    private void Update()
    {
        if (CanSpawn && canSpawnOthers)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = SpawnCounterDefault;
                CanSpawn = false;

                SpawnItem();
            }
        }
        if (IsJustOne)
            canSpawnOthers = false;
    }

    void SpawnItem()
    {
        int rnd = Random.Range(0, transform.childCount);
        GameObject go = Instantiate(Item, transform.GetChild(rnd));
        go.transform.position = go.transform.parent.position;
        go.GetComponent<Pickable>().Spawner = this;
        go.GetComponent<Pickable>().CreateItem();
    }


}
