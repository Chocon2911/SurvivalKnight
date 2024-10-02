using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemDropStat
{
    public ItemType ItemType;
    public ItemCode ItemCode;
    public int MaxStack;

    public void SetStat(ItemType itemType, ItemCode itemCode, int maxStack)
    {
        this.ItemType = itemType;
        this.ItemCode = itemCode;   
        this.MaxStack = maxStack;
    }
}
