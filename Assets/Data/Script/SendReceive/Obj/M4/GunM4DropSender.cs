using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunM4DropSender : ObjSender
{
    //==========================================Variable==========================================
    [Header("GunM4Drop Sender")]
    [SerializeField] protected List<M4Stat> stats;
    public List<M4Stat> Stats => stats;

    //===========================================Sender===========================================
    public virtual void Send(GunM4DropReceiver receiver)
    {
        receiver.Receive(this.objName, this.objId, this.stats);
    }

    //============================================Set=============================================
    public virtual void SetDefault(string objName, string objId, List<M4Stat> stats)
    {
        this.objName = objName;
        this.objId = objId;
        this.stats = stats;
    }
}
