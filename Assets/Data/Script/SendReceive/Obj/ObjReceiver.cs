using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjReceiver : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [Header("Obj Receiver")]
    // Stat
    [SerializeField] protected string objName;
    public string ObjName => objName;

    [SerializeField] protected string objId;
    public string ObjId => objId;
}
