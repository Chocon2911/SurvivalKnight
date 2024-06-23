using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjStat : AtkableObjStat
{
    [Header("Enemy Obj Stat")]
    [Header("Other")]
    [SerializeField] protected EnemySO so;
    public EnemySO SO => so;

    [Header("Script")]
    [SerializeField] protected EnemyObjManager manager;
    public EnemyObjManager Manager => manager;

    [Header("Stat")]
    [SerializeField] protected float detectRange;
    public float DetectRange => detectRange;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadSO();
        
        //Script
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<EnemyObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Obj/AtkableObj/Enemy/" + transform.name;
        this.so = Resources.Load<EnemySO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        if (this.so == null)
        {
            Debug.LogError(transform.name + ": SO is null", transform.gameObject);
            return;
        }

        //Base Obj
        this.objName = this.so.name;
        this.objType = ObjType.AtkableObj;

        //Atk Obj
        this.maxHealth = this.so.MaxHealth;
        this.health = this.maxHealth;
        this.moveSpeed = this.so.MoveSpeed;
        this.atkDamage = this.so.AttackDamage;
        this.atkSpeed = this.so.AttackSpeed;
        this.amor = this.so.Amor;
        this.charactecterLevel = this.so.CharacterLevel;
        this.atkObjType = AtkObjType.Enemy;

        //Enemy
        this.detectRange = this.so.DetectRange;
    }
}
