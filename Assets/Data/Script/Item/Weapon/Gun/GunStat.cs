using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStat : HuyMonoBehaviour
{
    [Header("Gun Stat")]
    [Header("Other")]
    [SerializeField] protected GunSO so;
    public GunSO SO => so;

    [Header("Stat")]
    public int currLevel;

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

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSO();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Item/Weapon/Gun/" + transform.name;
        this.so = Resources.Load<GunSO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        if (this.so != null)
        {
            Debug.LogError(transform.name + ": SO is null", transform.gameObject);
            return;
        }

        if (this.currLevel <= 0 || this.currLevel >= this.so.UpgradeLevels.Count)
        {
            Debug.LogError(transform.name + ": currLevel is error", transform.gameObject);
        }

        this.BulletName = this.so.UpgradeLevels[this.currLevel].BulletName;
        this.BulletSpeed = this.so.UpgradeLevels[this.currLevel].BulletSpeed;
        this.ShootCooldown = this.so.UpgradeLevels[this.currLevel].ShootCooldown;
        this.ShootCooldownTimer = this.ShootCooldown;
        this.ShootChargeTime = this.so.UpgradeLevels[this.currLevel].ShootChargeTime;
        this.ShootChargeTimer = 0;
        this.ShootTime = this.so.UpgradeLevels[this.currLevel].ShootTime;
        this.ShootTimer = 0;
        this.BulletAppearRad = this.so.UpgradeLevels[this.currLevel].BulletAppearRad;
    }
}
