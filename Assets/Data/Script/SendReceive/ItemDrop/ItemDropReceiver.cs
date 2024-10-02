using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropReceiver : HuyMonoBehaviour
{
    public ItemDropStat Stat;
    public int Amount;
    public int Id;

    public virtual void SetStat(ItemDropStat stat, int amount, int id)
    {
        this.Stat = stat;
        this.Amount = amount;
        this.Id = id;
    }
}
