using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MovementRb : BaseMovement
{
    [Header("Movement Rb")]
    // Other
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;
    
    // Stat
    [SerializeField] protected MovementRbType movementRbType;
    public MovementRbType MovementRbType => movementRbType;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRb();
    }

    protected virtual void Update()
    {
        this.Move();
    }

    //=======================================Load Component=======================================
    protected abstract void LoadRb();
}
