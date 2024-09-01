using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunM4 : GunM4
{
    [Header("Player Gun M4")]
    // Script
    [SerializeField] protected PlayerObjWeapon weapon;
    public PlayerObjWeapon Weapon => weapon;

    [SerializeField] protected PlayerSingleShootM4 skill1;
    public PlayerSingleShootM4 Skill1 => skill1;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapon();
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

    //========================================Player Shoot========================================
    protected virtual void PlayerShoot()
    {
        if (InputManager.Instance.LeftMouse)
        {
            this.skill1.ActivateSkill();
        }
    }
}
