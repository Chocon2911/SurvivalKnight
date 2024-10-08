using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    [Header("EnemySpawner")]
    [Header("Stat")]
    [SerializeField] protected int maxAmount;
    public int MaxAmount => maxAmount;

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

    //==========================================Spawner===========================================
    public override Transform SpawnByObj(Transform spawnObj, Vector3 spawnPos, Quaternion spawnRot)
    {
        if (this.maxAmount <= (this.holderObj.childCount - this.holders.Count)) return null;
        return base.SpawnByObj(spawnObj, spawnPos, spawnRot);
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
            // When it reaches max amount, it will be null
        }

        else
        {
            newEnemyObj.gameObject.SetActive(true);
        }
            
        StartCoroutine(SpawnObjByTime(spawnDelay));
    }
}
