using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjSender : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [Header("Obj Sender")]
    // Stat
    [SerializeField] protected string objName;
    public string ObjName => ObjName;

    [SerializeField] protected string objId;
    public string ObjId => objId;
}
