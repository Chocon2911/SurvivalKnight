using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerObjAbstract : HuyMonoBehaviour
{
    #region Variable
    [Header("Player Obj Abstract")]
    // Script
    [SerializeField] protected PlayerObjManager manager;
    public PlayerObjManager Manager => manager;
    #endregion

    #region Unity
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }
    #endregion

    #region Load Component
    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }
    #endregion
}
