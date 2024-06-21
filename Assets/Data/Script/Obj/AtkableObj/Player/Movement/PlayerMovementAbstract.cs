using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAbstract : HuyMonoBehaviour
{
    #region Variable
    [Header("PLayer Movement")]
    [SerializeField] protected PlayerMovementManager movement;
    public PlayerMovementManager Movement => movement;
    #endregion


    #region Unity
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMovement();
    }
    #endregion

    #region Load Component
    //=======================================Load Component=======================================
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.GetComponent<PlayerMovementManager>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }
    #endregion
}
