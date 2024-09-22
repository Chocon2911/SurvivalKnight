using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : HuyMonoBehaviour
{
    [Header("Inventory")]
    // Script
    [SerializeField] protected List<ItemInventory> itemInventorys;
    public List<ItemInventory> ItemInventorys => itemInventorys;

    // Stat
    public int maxAmount;

    //=========================================Inventory==========================================
    public virtual void AddItem(ItemInventory newItemInventory)
    {
        foreach (ItemInventory itemInventory in this.itemInventorys)
        {
            if (itemInventory.SO.ItemCode != newItemInventory.SO.ItemCode) continue;
            if (itemInventory.Amount == itemInventory.SO.MaxStack) continue;


        }
    }
}
