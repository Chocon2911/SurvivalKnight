using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunM4DropReceiver : ObjReceiver
{
    //==========================================Variable==========================================
    [Header("GunM4Drop Receiver")]
    [SerializeField] protected List<M4Stat> stats;
    public List<M4Stat> Stats => stats;

    //==========================================Receiver==========================================
    public virtual void Receive(string objName, string objId, List<M4Stat> stats)
    {
        this.objName = objName;
        this.objId = objId;
        this.stats = stats;
    }
}
