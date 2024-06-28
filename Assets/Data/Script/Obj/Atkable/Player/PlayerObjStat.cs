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
    public float Satiety;
    //Dash
    public float DashSpeed;
    public float DashCooldown;
    public float DashChargeTime;
    public float DashTime;
    //Shoot
    public float BulletSpeed;
    public float ShootCooldown;
    public float ShootChargeTime;
    public float ShootTime;
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
        this.ObjType = ObjType.AtkableObj;
        this.ObjName = this.playerSO.ObjName;

        //Atkable Obj
        this.MaxHealth = this.playerSO.MaxHealth;
        this.Health = this.MaxHealth;
        this.MoveSpeed = this.playerSO.MoveSpeed;
        this.AtkDamage = this.playerSO.AttackDamage;
        this.AtkSpeed = this.playerSO.AttackSpeed;
        this.Amor = this.playerSO.Amor;
        this.CharacterLevel = this.playerSO.CharacterLevel;
        this.AtkObjType = AtkObjType.Player;

        //Player
        this.Satiety = this.playerSO.Satiety;
        //Dash
        this.DashSpeed = this.playerSO.DashSpeed;
        this.DashCooldown = this.playerSO.DashCooldown;
        this.DashChargeTime = this.playerSO.DashChargeTime;
        this.DashTime = this.playerSO.DashTime;
        //Shoot
        this.BulletSpeed = this.playerSO.BulletSpeed;
        this.ShootCooldown = this.PlayerSO.ShootCooldown;
        this.ShootChargeTime = this.PlayerSO.ShootChargeTime;
        this.ShootTime = this.playerSO.ShootTime;

        //Load Stat
        this.manager.Movement.DefaultStat();
        this.manager.Skill.Dash.DefaultStat();
    }
    #endregion
}
