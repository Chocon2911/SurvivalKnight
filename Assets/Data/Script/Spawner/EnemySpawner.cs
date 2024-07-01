using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    //===========================================Unity============================================
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One EnemySpawner Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    protected virtual void Start()
    {
        this.TestSpawn();
    }

    //===========================================Tester===========================================
    protected virtual void TestSpawn()
    {
        StartCoroutine(SpawnObjByTime(5));
    }

    protected virtual IEnumerator SpawnObjByTime(float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);

        string spawnName = this.prefabs[0].name;
        Vector3 spawnPos = Vector3.zero;
        Quaternion spawnRot = Quaternion.identity;

        Transform newEnemyObj = this.SpawnByName(spawnName, spawnPos, spawnRot);
        if (newEnemyObj == null)
        {
            Debug.LogError(transform.name + ": new enemy obj is null", transform.gameObject);
        }

        else
        {
            newEnemyObj.gameObject.SetActive(true);
        }

        StartCoroutine(SpawnObjByTime(spawnDelay));
    }
}
