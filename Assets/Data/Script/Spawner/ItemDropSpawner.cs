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
    public virtual void DropItems(List<ItemDropStat> itemDropStats, Vector2 droppableArea, Vector3 spawnPos, Quaternion spawnRot)
    {
        List<Transform> dropItems = new List<Transform>();
        foreach (ItemDropStat itemDropStat in itemDropStats)
        {
            int dropAmount = GetDroppableItemByRate(itemDropStat);
            for (int i = 0; i < dropAmount; i++)
            {
                Vector3 dropPos = this.GetRandomDropPos(droppableArea, spawnPos);
                Transform newItemObj = this.SpawnByName(itemDropStat.ItemDropSO.name, dropPos, spawnRot);
                if (newItemObj == null)
                {
                    Debug.LogError(transform.name + ": NewItemObj is null", transform.gameObject);
                    continue;
                }

                dropItems.Add(newItemObj);
            }
        }

        foreach (Transform newItemObj in dropItems)
        {
            newItemObj.gameObject.SetActive(true);
        }
    }

    protected virtual int GetDroppableItemByRate(ItemDropStat itemDropStat)
    {
        int droppableItem = itemDropStat.MinAmount;

        for (int i = 0; i < itemDropStat.MaxAmount - itemDropStat.MinAmount; i++)
        {
            float randomRate = Random.Range(0, 100 * 1000) / 1000;
            if (randomRate > itemDropStat.DropRate) continue;

            droppableItem++;
        }

        return droppableItem;
    }

    protected virtual Vector3 GetRandomDropPos(Vector2 droppableArea, Vector3 spawnPos)
    {
        float xDropArea = Random.Range(-droppableArea.x, droppableArea.x);
        float yDropArea = Random.Range(-droppableArea.y, droppableArea.y);

        return new Vector3(xDropArea, yDropArea, 0) + spawnPos;
    }
}
