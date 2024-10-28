using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDataReceiver : HuyMonoBehaviour
{
    public ItemDropSO SO;
    public int Amount;

    //==========================================Receive===========================================
    public virtual void Recieve(ItemDropSO so, int amount)
    {
        this.SO = so;
        this.Amount = amount;
    }
}
