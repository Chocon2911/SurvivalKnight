using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSR : HuyMonoBehaviour
{
    [Header("Damage")]
    [Header("Stat")]
    [SerializeField] protected float atkDamage;
    public float AtkDamage => atkDamage;

    //===========================================Other============================================
    public abstract void DefaultStat();
}
