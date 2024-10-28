using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerObjPickUpItemAbstract : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [Header("Player Obj Pick Up Item Abstract")]
    [SerializeField] protected PlayerObjPickUpItem pickUpItem;
    public PlayerObjPickUpItem PickUpItem => pickUpItem;

    [SerializeField] protected ItemDropDataReceiver itemDropReceiver;
    public ItemDropDataReceiver ItemDropReceiver => itemDropReceiver;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPickUpItem();
        this.LoadItemDropReceiver();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadPickUpItem()
    {
        if (this.pickUpItem != null) return;
        this.pickUpItem = transform.parent.GetComponent<PlayerObjPickUpItem>();
        Debug.LogWarning(transform.name + ": Load PickUpItem", transform.gameObject);
    }

    protected virtual void LoadItemDropReceiver()
    {
        if (this.itemDropReceiver != null) return;
        this.itemDropReceiver = transform.Find("ItemDropReceiver").GetComponent<ItemDropDataReceiver>();
        Debug.LogWarning(transform.name + ": Load Receiver", transform.gameObject);
    }

    //==========================================Pick Up===========================================
    protected virtual void AddItemDropToInventory(ItemDropObjManager manager)
    {
        ItemDropDataSender sender = manager.DataSender;
        ItemDropObjStat stat = manager.Stat;

        sender.Send(this.ItemDropReceiver);
        ItemInventory newItemInventory = new ItemInventory
            (this.itemDropReceiver.SO, this.itemDropReceiver.Amount);
        ItemInventory leftItemInventory = PlayerManager.Instance.Inventory.AddItemInventory(newItemInventory);

        if (leftItemInventory != null)
        {
            stat.Amount = leftItemInventory.Amount;
            return;
        }

        stat.Amount = 0;
    }
}
