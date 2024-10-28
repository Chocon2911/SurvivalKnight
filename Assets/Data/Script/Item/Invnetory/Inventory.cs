using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : HuyMonoBehaviour
{
    [Header("Inventory")]
    // Script
    [SerializeField] protected List<ItemInventory> itemInventorys = new List<ItemInventory>();
    public List<ItemInventory> ItemInventorys => itemInventorys;

    // Stat
    public int MaxSlot;

    //=========================================Inventory==========================================
    public virtual void AddItemDrop(ItemDropObjManager manager)
    {

    }
    
    public virtual ItemInventory AddItemInventory(ItemInventory newItemInventory)
    {
        foreach (ItemInventory itemInventory in this.itemInventorys)
        {
            if (itemInventory.Amount <= 0) break;
            if (itemInventory.SO.ItemCode != newItemInventory.SO.ItemCode) continue;
            if (itemInventory.Amount >= itemInventory.SO.MaxStack) continue;

            if (newItemInventory.Amount >= itemInventory.SO.MaxStack - itemInventory.Amount)
            {
                newItemInventory.Amount = itemInventory.SO.MaxStack - itemInventory.Amount;
                itemInventory.Amount = itemInventory.SO.MaxStack;
                continue;
            }
    
            itemInventory.Amount += newItemInventory.Amount;
            break;
        }

        if (this.itemInventorys.Count >= this.MaxSlot)
        {
            Debug.Log(transform.name + ": Inventory is full", transform.gameObject);
            return new ItemInventory(newItemInventory.SO, newItemInventory.Amount);
        }

        string newId = RandomString.GetRandomId(10);
        this.itemInventorys.Add(new ItemInventory(newItemInventory.SO, newItemInventory.Amount, newId));
        return null;
    }
}
