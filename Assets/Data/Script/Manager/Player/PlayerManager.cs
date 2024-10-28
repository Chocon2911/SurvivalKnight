using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    private static PlayerManager instance;
    public static PlayerManager Instance => instance;

    [Header("Player Manager")]
    [SerializeField] protected PlayerInventory inventory;
    public PlayerInventory Inventory => inventory;

    //===========================================Unity============================================
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("One PlayerManager Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.Find("Inventory").GetComponent<PlayerInventory>();
        Debug.LogWarning(transform.name + ": Load Invnetory", transform.gameObject);
    }
}
