using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    //==========================================Variable==========================================
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    [Header("EquipmentDrop Spawner")]
    //Stat
    public Vector2 distanceBtwItems;

    private string gunM4Drop = "M4Drop";
    public string GunM4Drop => gunM4Drop;

    //===========================================Unity============================================
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One EquipmentDropSpawner Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    //============================================Drop============================================
    
}
