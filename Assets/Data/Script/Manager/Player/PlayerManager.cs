using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    private static PlayerManager instance;
    public static PlayerManager Instance => instance;

    [Header("Player Manager")]
    [SerializeField] protected PlayerPickUpItem pickUpItem;
    public PlayerPickUpItem PickUpItem => pickUpItem;

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
        this.LoadPickUpItem();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadPickUpItem()
    {
        if (this.pickUpItem != null) return;
        this.pickUpItem = transform.Find("PickUpItem").GetComponent<PlayerPickUpItem>();
        Debug.LogWarning(transform.name + ": Load PickUpItem", transform.gameObject);
    }
}
