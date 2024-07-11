using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MovementRb : BaseMovement
{
    [Header("Movement Rb")]
    [Header("Other")]
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    //===========================================Unity============================================
    protected virtual void Update()
    {
        this.Move();
    }

    //==========================================Movement==========================================
    protected abstract void Move();

    //=======================================Load Component=======================================
    public void SetRb(Rigidbody2D rb)
    {
        this.rb = rb;
    }

}
