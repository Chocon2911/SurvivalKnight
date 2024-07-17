using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjMovement : PlayerObjAbstract
{
    [Header("Player Obj Movement")]
    [Header("Script")]
    [SerializeField] protected PlayerMoveByKeyBoard keyBoard;
    public PlayerMoveByKeyBoard KeyBoard => keyBoard;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadKeyBoard();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadKeyBoard()
    {
        if (this.keyBoard != null) return;
        this.keyBoard = transform.GetComponentInChildren<PlayerMoveByKeyBoard>();
        Debug.LogWarning(transform.name + ": Load KeyBoard", transform.gameObject);
    }
}
