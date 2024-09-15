using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDropSpawner : Spawner
{
    //==========================================Variable==========================================
    private static EquipmentDropSpawner instance;
    public static EquipmentDropSpawner Instance => instance;

    [Header("EquipmentDrop Spawner")]
    //Stat
    [SerializeField] protected string gunM4Drop = "M4Drop";
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
}
