using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AtkableObjStat : BaseObj
{
    #region Variable
    public float MaxHealth ;
    public float Health;
    public float MoveSpeed;
    public float AtkDamage;
    public float AtkSpeed;
    public float Amor;
    public int CharacterLevel;
    public AtkObjType AtkObjType;
    #endregion
}
