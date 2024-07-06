using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjStat : BaseObj
{
    [Header("Bullet Obj Stat")]
    [Header("Stat")]
    //Fly
    public float FlySpeed;

    //DespawnByTime
    public float ExistTime;
    public float ExistTimer;

    //DamageSender
    public float Damage;
    public AtkObjType CanDamageType;

    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    [Header("Other")]
    [SerializeField] protected BulletSO so;
    public BulletSO SO => so;

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
    //Other
    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Obj/Bullet/" + transform.name;
        this.so = Resources.Load<BulletSO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    //Script
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<BulletObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        if (this.so == null)
        {
            Debug.LogError(transform.name + ": SO is null", transform.gameObject);
            return;
        }

        //BaseObj
        this.ObjType = ObjType.Bullet;
        this.ObjName = this.so.ObjName;

        //BulletObjStat
        //Fly
        this.FlySpeed = this.so.FlySpeed;
        this.ExistTime = this.so.ExistTime;
        this.ExistTimer = 0;
        //DamageSender
        this.Damage = this.so.Damage;
        this.CanDamageType = this.so.CanDamageType;
    }
}
