using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : PlayerObjAbstract
{
    #region Variable
    [Header("Player Movement Manager")]
    [Header("Script")]
    [SerializeField] protected PlayerMove move;
    public PlayerMove Move => move;

    [SerializeField] protected PlayerDash dash;
    public PlayerDash Dash => dash;
    #endregion

    #region Unity
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMove();
        this.LoadDash();
    }
    #endregion

    #region Load Component
    //=======================================Load Component=======================================
    protected virtual void LoadMove()
    {
        if (this.move != null) return;
        this.move = transform.GetComponentInChildren<PlayerMove>();
        Debug.LogWarning(transform.name + ": Load Move", transform.gameObject);
    }

    protected virtual void LoadDash()
    {
        if (this.dash != null) return;
        this.dash = transform.GetComponentInChildren<PlayerDash>();
        Debug.LogWarning(transform.name + ": Load Dash", transform.gameObject);
    }
    #endregion
}
