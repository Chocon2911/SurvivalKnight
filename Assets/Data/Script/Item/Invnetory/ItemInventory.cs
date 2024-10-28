using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public ItemDropSO SO;
    public int Amount;
    
    [SerializeField] string id;
    public string Id => id;

    public ItemInventory()
    {
        this.SO = null;
        this.Amount = 0;
    }

    public ItemInventory(ItemDropSO so, int amount)
    {
        this.SO = so;
        this.Amount = amount;
    }

    public ItemInventory(ItemDropSO so, int amount, string id)
    {
        this.SO = so;
        this.Amount = amount;
        this.id = id;
    }
}
