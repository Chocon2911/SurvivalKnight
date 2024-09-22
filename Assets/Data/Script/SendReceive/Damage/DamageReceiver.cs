using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : HuyMonoBehaviour
{
    [Header("Damage Receiver")]
    [Header("Stat")]
    public float Hp;

    //Get Set
    public AtkObjType AtkObjType;

    //==========================================Receive===========================================
    public virtual void Receive(float damage)
    {
        this.Hp -= damage;
        if (this.Hp < 0) this.Hp = 0;
    }
}
