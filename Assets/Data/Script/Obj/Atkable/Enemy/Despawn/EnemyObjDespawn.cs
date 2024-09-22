using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjDespawn : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [Header("Enemy Obj Despawn")]
    // Script
    [SerializeField] protected EnemyObjManager manager;
    public EnemyObjManager Manager => manager;

    [SerializeField] protected EnemyObjDespawnByHealth byHealth;
    public EnemyObjDespawnByHealth ByHealth => byHealth;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
        this.LoadByHealth();
    }

    //=======================================Load Component=======================================
    // Script
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.gameObject.GetComponent<EnemyObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    protected virtual void LoadByHealth()
    {
        if (this.byHealth != null) return;
        this.byHealth = transform.Find("ByHealth").GetComponent<EnemyObjDespawnByHealth>();
        Debug.LogWarning(transform.name + ": Load ByHealth", transform.gameObject);
    }
}
