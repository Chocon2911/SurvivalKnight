using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : HuyMonoBehaviour
{
    [Header("Damage Sender")]
    public List<AtkObjType> AtkObjTypes;
    public float AtkDamage;

    //============================================Send============================================
    public virtual void Send(DamageReceiver receiver)
    {
        foreach (AtkObjType type in this.AtkObjTypes)
        {
            if (receiver.AtkObjType != type) return;
            receiver.Receive(this.AtkDamage);
        }
    }
}
