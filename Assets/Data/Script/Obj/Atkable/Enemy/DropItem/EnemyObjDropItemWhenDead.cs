using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjDropItemWhenDead : HuyMonoBehaviour, IEnemyObjDespawnByHealthObserver
{
    [Header("EnemyDropItemWhenDead")]
    [SerializeField] protected EnemyObjManager manager;
    public EnemyObjManager Manager => manager;

    //===========================================Unity============================================
    protected virtual void Start()
    {
        this.RegisterObserver();
    }
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": Load Manager", transform.gameObject);
    }

    //============================Enemy Obj Despawn By Health Observer============================
    public void OnDespawn()
    {
        List<ItemDropByRate> itemDropByRate = this.manager.SO.DropList;
        Vector2 dropArea = new Vector2(1, 1);
        Vector3 spawnPos = this.manager.transform.position;
        Quaternion spawnRot = Quaternion.identity;

        ItemDropSpawner.Instance.DropItemsByRate(itemDropByRate, dropArea, spawnPos, spawnRot);
    }

    protected virtual void RegisterObserver()
    {
        this.manager.Despawn.ByHealth.AddObserver(this);
    }
}
