using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One BulletSpawner Only", transform.gameObject);
            return;
        }
        instance = this;

        base.Awake();
    }

    //===========================================Unity============================================
    protected virtual void Start()
    {
        //this.SpawnTest();
    }

    //===========================================Tester===========================================
    //protected virtual void SpawnTest()
    //{
    //    StartCoroutine(this.SpawnObj());
    //}

    //protected virtual IEnumerator SpawnObj()
    //{
    //    Vector3 spawnPos = Vector3.zero;
    //    Quaternion spawnRot = Quaternion.identity;
    //    string objName = this.prefabs[0].name;

    //    Transform newBullet = this.SpawnByName(objName, spawnPos, spawnRot);

    //    if (newBullet == null)
    //    {
    //        Debug.LogError(transform.name + ": New Bullet is null", transform.gameObject);
    //    }

    //    else
    //    {
    //        newBullet.gameObject.SetActive(true);
    //    }

    //    yield return new WaitForSeconds(3);
    //    StartCoroutine(this.SpawnObj());
    //}
}
