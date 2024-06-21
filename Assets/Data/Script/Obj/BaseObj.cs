using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObj : HuyMonoBehaviour
{
    #region Varibale
    [Header("Base Obj")]
    [SerializeField] protected ObjType objType;
    public ObjType ObjType => objType;

    [SerializeField] protected string objName;
    public string ObjName => objName;
    #endregion
}
