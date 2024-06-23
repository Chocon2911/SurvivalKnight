using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class PlayerObjStat : AtkableObjStat
{
    #region Player Obj Stat
    [Header("Player Obj Stat")]
    [Header("Other")]
    [SerializeField] protected PlayerSO playerSO;
    public PlayerSO PlayerSO => playerSO;

    [Header("Script")]
    [SerializeField] protected PlayerObjManager manager;
    public PlayerObjManager Manager => manager;

    [Header("Stat")]
    [SerializeField] protected float satiety;
    public float Satiety => satiety;

    [SerializeField] protected float dashSpeed;
    public float DashSpeed => dashSpeed;

    [SerializeField] protected float dashCooldown;
    public float DashCooldown => dashCooldown;

    [SerializeField] protected float dashTime;
    public float DashTime => dashTime;
    #endregion



    #region Unity
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadPlayerSO();

        //Script
        this.LoadManager();
    }
    #endregion



    #region Load Component
    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadPlayerSO()
    {
        if (this.playerSO != null) return;
        string filePath = "Obj/AtkableObj/Player/" + transform.name;
        this.playerSO = Resources.Load<PlayerSO>(filePath);
        Debug.LogWarning(transform.name + ": Load PlayerSO", transform.gameObject);
    }

    //Script
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<PlayerObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }
    #endregion



    #region Other
    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        if (this.playerSO == null)
        {
            Debug.LogError(transform.name + ": PlayerSO is null", transform.gameObject);
            return;
        }

        //Obj
        this.objType = ObjType.AtkableObj;
        this.objName = this.playerSO.ObjName;

        //Atkable Obj
        this.maxHealth = this.playerSO.MaxHealth;
        this.health = this.maxHealth;
        this.moveSpeed = this.playerSO.MoveSpeed;
        this.atkDamage = this.playerSO.AttackDamage;
        this.atkSpeed = this.playerSO.AttackSpeed;
        this.amor = this.playerSO.Amor;
        this.charactecterLevel = this.playerSO.CharacterLevel;

        //Player
        this.satiety = this.playerSO.Satiety;
        this.dashSpeed = this.playerSO.DashSpeed;
        this.dashCooldown = this.playerSO.DashCooldown;
        this.dashTime = this.playerSO.DashTime;
    }
    #endregion
}
