using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDespawn : PlayerAbstract
{
    //==========================================Variable==========================================
    [Header("Player Obj Despawn")]
    [SerializeField] protected PlayerObjDespawnByHealth byHealth;
    public PlayerObjDespawnByHealth ByHealth => byHealth;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadByHealth();
    }

    protected virtual void LoadByHealth()
    {
        if (this.byHealth != null) return;
        {
            this.byHealth = transform.Find("ByHealth").GetComponent<PlayerObjDespawnByHealth>();
            Debug.LogWarning(transform.name + ": Load ByHealth", transform.gameObject);
        }
    }
}
