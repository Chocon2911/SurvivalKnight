using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjMovement : HuyMonoBehaviour
{
    [Header("Enemy Movement")]
    // Other
    [SerializeField] protected CircleCollider2D detectCollide;

    // Script
    [SerializeField] protected EnemyObjManager manager;
    public EnemyObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        // Other
        this.LoadDetectCollide();
        // Script
        this.LoadManager();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    //=======================================Load Component=======================================
    // Other
    protected virtual void LoadDetectCollide()
    {
        if (this.detectCollide != null) return;
        this.detectCollide = transform.GetComponent<CircleCollider2D>();
        Debug.LogWarning(transform.name + ": Load DetectCollide", transform.gameObject);
    }

    // Script
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }
}
