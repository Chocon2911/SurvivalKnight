using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AtkableObjStat : BaseObj
{
    #region Variable
    [SerializeField] protected float maxHealth = 0;
    public float MaxHealth => maxHealth;

    [SerializeField] protected float health = 0;
    public float Health => health;

    [SerializeField] protected float moveSpeed = 0;
    public float MoveSpeed => moveSpeed;

    [SerializeField] protected float atkDamage;
    public float AtkDamage => atkDamage;

    [SerializeField] protected float atkSpeed;
    public float AtkSpeed => atkSpeed;

    [SerializeField] protected float amor;
    public float Amor => amor;

    [SerializeField] protected int charactecterLevel;
    public int CharacterLevel => charactecterLevel;

    [SerializeField] protected AtkObjType atkObjType;
    public AtkObjType AtkObjType => atkObjType;
    #endregion
}
