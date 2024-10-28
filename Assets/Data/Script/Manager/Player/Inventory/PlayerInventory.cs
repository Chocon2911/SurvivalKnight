using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    [Header("Player Inventory")]
    [SerializeField] protected PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;

    //=======================================Load Component=======================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadPlayerManager()
    {
        if (this.PlayerManager != null) return;
        this.playerManager = transform.parent.GetComponent<PlayerManager>();
        Debug.LogWarning(transform.name + ": Load PlayerManager");
    }
}
