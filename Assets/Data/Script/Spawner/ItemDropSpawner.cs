using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    //==========================================Variable==========================================
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    [Header("EquipmentDrop Spawner")]
    //Stat
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
    public virtual void DropItemsByRate(List<ItemDropByRate> itemDropByRates, Vector2 droppableArea, Vector3 spawnPos, Quaternion spawnRot)
    {
        List<Transform> dropItemObjs = new List<Transform>();
        foreach (ItemDropByRate itemDropByRate in itemDropByRates)
        {
            foreach (Transform itemDrop in this.DropItemByRate(itemDropByRate, droppableArea, spawnPos, spawnRot))
            {
                dropItemObjs.Add(itemDrop);
            }
        }

        foreach (Transform newItemObj in dropItemObjs)
        {
            newItemObj.gameObject.SetActive(true);
        }
    }

    public virtual List<Transform> DropItemByRate(ItemDropByRate itemDropStat, Vector2 droppableArea, Vector3 spawnPos, Quaternion spawnRot)
    {
        int dropAmount = GetItemAmountByRate(itemDropStat);
        List<Transform> itemDropObjs = new List<Transform>();
        for (int i = 0; i < dropAmount; i++)
        {
            Vector3 dropPos = this.GetRandomDropPos(droppableArea, spawnPos);
            Transform newItemObj = this.SpawnByName(itemDropStat.ItemDropSO.name, dropPos, spawnRot);
            if (newItemObj == null)
            {
                Debug.LogError(transform.name + ": NewItemObj is null", transform.gameObject);
                continue;
            }

            itemDropObjs.Add(newItemObj);
        }

        return itemDropObjs;
    }

    public virtual void DropItemByItemInventory(ItemInventory itemInventory, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newItemDrop = this.SpawnByName(itemInventory.SO.name, spawnPos, spawnRot);
        if (newItemDrop == null)
        {
            Debug.Log(transform.name + ": ItemDrop is null", transform.gameObject);
            return;
        }

        ItemDropObjStat stat = newItemDrop.GetComponent<ItemDropObjStat>();
        if (stat == null)
        {
            Debug.LogError(transform.name + ": No ItemDropObjStat in ItemDrop", transform.gameObject);
            return;
        }

        stat.Amount = itemInventory.Amount;
        newItemDrop.gameObject.SetActive(true);
    }

    //============================================Get=============================================
    protected virtual int GetItemAmountByRate(ItemDropByRate itemDropStat)
    {
        float randomRate = Random.Range(0, 100000) / 1000;
        foreach (ItemDropRate itemDropRate in itemDropStat.ItemDropRates)
        {
            if (randomRate > itemDropRate.DropRate) continue;
            return itemDropRate.Amount;
        }

        return 0;
    }

    protected virtual Vector3 GetRandomDropPos(Vector2 droppableArea, Vector3 spawnPos)
    {
        float xDropArea = Random.Range(-droppableArea.x, droppableArea.x);
        float yDropArea = Random.Range(-droppableArea.y, droppableArea.y);

        return new Vector3(xDropArea, yDropArea, 0) + spawnPos;
    }
}
