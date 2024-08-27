using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDataSender : HuyMonoBehaviour
{
    [Header("Bullet Data Sender")]
    // Stat
    public float Damage;
    public float BulletSpeed;
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

        receiver.Receive(this.Damage, this.BulletSpeed, this.BulletDespawnTime, this.BulletDespawnDistance);
    }

    //===========================================Other============================================
    public virtual void DefaultStat(float damage, float bulletSpeed, float bulletDespawnTime, float bulletDespawnDistance)
    {
        this.Damage = damage;
        this.BulletSpeed = bulletSpeed;
        this.BulletDespawnTime = bulletDespawnTime;
        this.BulletDespawnDistance = bulletDespawnDistance;
    }
}
