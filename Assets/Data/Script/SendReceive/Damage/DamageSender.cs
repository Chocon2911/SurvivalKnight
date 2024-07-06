using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : DamageSR
{
    //============================================Send============================================
    protected virtual void Send(DamageReceiver receiver)
    {
        receiver.Receive(this.AtkDamage);
    }
}
