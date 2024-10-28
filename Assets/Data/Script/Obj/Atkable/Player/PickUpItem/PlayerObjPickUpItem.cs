using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjPickUpItem : PlayerObjAbstract
{
    //==========================================Variable==========================================
    [Header("Plyaer Obj Pick Up Item")]
    [SerializeField] protected PlayerObjPickUpItemByPress byPress;
    public PlayerObjPickUpItemByPress ByPress => byPress;

    [SerializeField] protected PlayerObjPickUpItemByCollide byCollide;
    public PlayerObjPickUpItemByCollide ByCollide => byCollide;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadByPress();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadByPress()
    {
        if (this.byPress != null) return;
        this.byPress = transform.Find("ByPress").GetComponent<PlayerObjPickUpItemByPress>();
        Debug.LogWarning(transform.name + ": Load ByPress", transform.gameObject);
    }
}
