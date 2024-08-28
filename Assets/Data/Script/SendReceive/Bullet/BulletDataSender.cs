using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDataSender : HuyMonoBehaviour
{
    [Header("Bullet Data Sender")]
    // Stat
    public float Damage;
    public float BulletSpeed;
    public Vector2 FlyDir;
    public float BulletDespawnTime;
    public float BulletDespawnDistance;

    //===========================================Sender===========================================
    public virtual void Send(BulletDataReceiver receiver)
    {
        if (receiver == null)
        {
            Debug.LogError(transform.name + ": Receiver is null");
            return;
        }

        receiver.Receive(this.Damage, this.BulletSpeed, this.FlyDir, this.BulletDespawnTime, this.BulletDespawnDistance);
    }

    //===========================================Other============================================
    public virtual void SetStat(float damage, float bulletSpeed, Vector2 flyDir, float bulletDespawnTime, float bulletDespawnDistance)
    {
        this.Damage = damage;
        this.BulletSpeed = bulletSpeed;
        this.FlyDir = flyDir;
        this.BulletDespawnTime = bulletDespawnTime;
        this.BulletDespawnDistance = bulletDespawnDistance;
    }
}
