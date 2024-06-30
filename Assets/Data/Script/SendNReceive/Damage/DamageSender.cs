using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : Damage
{
    //============================================Send============================================
    public virtual void Send(DamageReceiver receiver)
    {
        receiver.Receive(this.atkDamage);
    }
}
