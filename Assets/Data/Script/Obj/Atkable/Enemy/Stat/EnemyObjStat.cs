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
    //Movement
    public float DetectRange;


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
        this.ObjName = this.so.name;
        this.ObjType = ObjType.AtkableObj;

        //Atk Obj
        this.MaxHealth = this.so.MaxHealth;
        this.Health = this.MaxHealth;
        this.MoveSpeed = this.so.MoveSpeed;
        this.AtkDamage = this.so.AttackDamage;
        this.AtkSpeed = this.so.AttackSpeed;
        this.Amor = this.so.Amor;
        this.CharacterLevel = this.so.CharacterLevel;
        this.AtkObjType = AtkObjType.Enemy;

        //Enemy
        this.DetectRange = this.so.DetectRange;

        //Load Stat
        this.manager.Movement.DefaultStat();
        this.manager.DamageReceiver.DefaultStat();
    }
}
