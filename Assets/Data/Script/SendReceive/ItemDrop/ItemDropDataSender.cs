using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDataSender : HuyMonoBehaviour
{
    public ItemDropSO SO;
    public int Amount;

    public virtual void Send(ItemDropDataReceiver receiver)
    {
        if (receiver == null)
        {
            Debug.LogError(transform.name + ": Receiver is null", transform.gameObject);
            return;
        }    

        receiver.Recieve(this.SO, this.Amount);
    }
}
