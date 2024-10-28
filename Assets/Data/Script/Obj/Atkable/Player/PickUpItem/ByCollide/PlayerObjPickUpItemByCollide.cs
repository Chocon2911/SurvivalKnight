using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerObjPickUpItemByCollide : PlayerObjPickUpItemAbstract
{
    [Header("Player Obj Pick Up Item By Collide")]
    // Other
    [SerializeField] protected CircleCollider2D bodyCollide;
    public CircleCollider2D BodyCollide => bodyCollide;

    [SerializeField] protected List<ItemCode> itemCodes;
    public List<ItemCode> ItemCodes => itemCodes;

    // Stat
    public float CollideRad;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollide();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        ItemDropObjManager manager = collision.transform.GetComponent<ItemDropObjManager>();
        if (manager == null) return;

        foreach (ItemCode itemCode in this.itemCodes)
        {
            if (itemCode != manager.Stat.ItemCode) continue;

            if (manager.Stat.ItemType == ItemType.Equipment ||
                manager.Stat.ItemType == ItemType.Material)
            {
                this.AddItemDropToInventory(manager);
            }

            else if (manager.Stat.ItemType == ItemType.Resources)
            {
                
            }
        }
    }

    //=======================================Load Component=======================================
    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<CircleCollider2D>();
        this.bodyCollide.isTrigger = true;
        this.bodyCollide.radius = this.CollideRad;
        Debug.LogWarning(transform.name + ": Load BodyCollide", transform.gameObject);
    }

    //==========================================ItemCode==========================================
    public virtual void AddItemCode(ItemCode itemCode)
    {
        this.ItemCodes.Add(itemCode);
    }
}
