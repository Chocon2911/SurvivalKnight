using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerObjCtrl : PlayerObjAbstract
{
    [Header("Player Obj Ctrl")]
    [Header("Other")]
    [SerializeField] protected CapsuleCollider2D body;
    public CapsuleCollider2D Body => body;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadBody();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadBody()
    {
        if (this.body != null) return;
        this.body = transform.GetComponent<CapsuleCollider2D>();
        this.body.isTrigger = false;
        this.body.size = new Vector2(1, 1);
        Debug.LogWarning(transform.name + ": Load Body", transform.gameObject);
    }

    //============================================Ctrl============================================
}
