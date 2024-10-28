using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjPickUpItemByPress : PlayerObjPickUpItemAbstract
{
    //==========================================Variable==========================================
    [Header("Player Obj Pick Up Item By Press")]
    // Stat
    public float PickUpRad;
    public LayerMask PickUpAbleLayerMask;

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.PickUpAbleLayerMask = LayerMask.NameToLayer("Item");
    }

    //==========================================Pick Up===========================================
    protected virtual void DetectItemDrop(LayerMask itemDropLayerMask)
    {
        if (!InputManager.Instance.EPressed) return;

        Vector2 mainObjPos = this.PickUpItem.Manager.transform.position;
        Vector2 mousePos = GameManager.Instance.MousePos;

        RaycastHit2D rayCast = Physics2D.Raycast(mainObjPos, mousePos, this.PickUpRad, this.PickUpAbleLayerMask);
        if (!rayCast) return;
        
        ItemDropObjManager manager = rayCast.collider.transform.GetComponent<ItemDropObjManager>();
        if (manager == null)
        {
            Debug.LogError(transform.name + ": ItemDropManager is null", transform.gameObject);
            return;
        }

        this.AddItemDropToInventory(manager);
    }
}
