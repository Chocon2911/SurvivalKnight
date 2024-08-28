using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDataReceiver : HuyMonoBehaviour
{
    [Header("Bullet Data Receiver")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<BulletObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //==========================================Receiver==========================================
    public virtual void Receive(float damage, float bulletSpeed, Vector2 flyDir, float bulletDespawnTime, float bulletDespawnDistance)
    {
        this.manager.DamageSender.AtkDamage = damage;
        this.manager.Movement.Fly.MoveSpeed = bulletSpeed;
        this.manager.Movement.Fly.MoveDir = flyDir;
        this.manager.Despawn.ByTime.DespawnDelay = bulletDespawnTime;
    }
}
