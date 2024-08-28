using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : HuyMonoBehaviour
{
    [Header("Damage Sender")]
    public float AtkDamage;

    //============================================Send============================================
    protected virtual void Send(DamageReceiver receiver)
    {
        receiver.Receive(this.AtkDamage);
    }
}
