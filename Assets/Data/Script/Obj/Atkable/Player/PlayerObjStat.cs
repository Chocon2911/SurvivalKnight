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
    [Header("Dash")]
    public float DashSpeed;
    public float DashCooldown;
    public float DashCooldownTimer;
    public float DashChargeTime;
    public float DashChargeTimer;
    public float DashTime;
    public float DashTimer;
    //Shoot
    [Header("Shoot")]
    public string BulletName;
    public float BulletSpeed;
    public float ShootCooldown;
    public float ShootCooldownTimer;
    public float ShootChargeTime;
    public float ShootChargeTimer;
    public float ShootTime;
    public float ShootTimer;
    public float BulletAppearRad;
    //Shotgun
    [Header("Shotgun")]
    public string ShotgunBulletName;
    public float ShotgunBulletSpeed;
    public float ShotgunCooldown;
    public float ShotgunCooldownTimer;
    public float ShotgunChargeTime;
    public float ShotgunChargeTimer;
    public float ShotgunTime;
    public float ShotgunTimer;
    public int ShotgunPelletAmount;
    //DamageReceiver
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
        this.BulletName = this.playerSO.BulletName;
        this.BulletSpeed = this.playerSO.BulletSpeed;
        this.ShootCooldown = this.PlayerSO.ShootCooldown;
        this.ShootChargeTime = this.PlayerSO.ShootChargeTime;
        this.ShootTime = this.playerSO.ShootTime;
        this.BulletAppearRad = this.playerSO.BulletAppearRad;
        //Shotgun
        this.ShotgunBulletName = this.playerSO.ShotgunBulletName;
        this.ShotgunBulletSpeed = this.playerSO.ShotgunBulletSpeed;
        this.ShotgunCooldown = this.playerSO.ShotgunCooldown;
        this.ShotgunCooldownTimer = this.ShotgunCooldown;
        this.ShotgunChargeTime = this.playerSO.ShotgunChargeTime;
        this.ShotgunChargeTimer = this.ShotgunChargeTime;
        this.ShotgunTime = this.playerSO.ShotgunTime;
        this.ShotgunPelletAmount = this.playerSO.ShotgunPelletAmount;
        this.ShotgunTimer = this.ShotgunTime;
        //Damage Receiver


        //Load Stat
        this.manager.Skill.Dash.DefaultStat();
        this.manager.Skill.Shoot.DefaultStat();
        this.manager.Skill.Shotgun.DefaultStat();
        this.manager.DamageReceiver.DefaultStat();
    }
    #endregion
}
