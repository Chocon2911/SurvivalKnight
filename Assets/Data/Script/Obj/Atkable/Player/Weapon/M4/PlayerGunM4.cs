using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunM4 : GunM4
{
    [Header("Player Gun M4")]
    // Script
    [SerializeField] protected PlayerObjWeapon weapon;
    public PlayerObjWeapon Weapon => weapon;

    [SerializeField] protected PlayerSingleShootSkill singleShootSkill;
    public PlayerSingleShootSkill SingleShootSkill => singleShootSkill;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapon();
        this.LoadSingleShootSkill();
    }

    protected virtual void Update()
    {
        this.PlayerShoot();
    }

    //=======================================Load Component=======================================
    // Script
    protected virtual void LoadWeapon()
    {
        if (this.weapon != null) return;
        this.weapon = transform.parent.GetComponent<PlayerObjWeapon>();
        Debug.LogWarning(transform.name + ": Load Weapon", transform.gameObject);
    }

    protected virtual void LoadSingleShootSkill()
    {
        if (this.singleShootSkill != null) return;
        this.singleShootSkill = transform.Find("Shoot").GetComponent<PlayerSingleShootSkill>();
        Debug.LogWarning(transform.name + ": Load SingleShootSkill", transform.gameObject);
    }

    //========================================Player Shoot========================================
    protected virtual void PlayerShoot()
    {
        if (InputManager.Instance.LeftMouse) this.singleShootSkill.ActivateSkill();
    }
}
