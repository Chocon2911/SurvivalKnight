using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunM4 : GunM4
{
    [Header("Player Gun M4")]
    // Script
    [SerializeField] protected PlayerObjWeapon weapon;
    public PlayerObjWeapon Weapon => weapon;
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
        foreach (WeaponSkill skill in this.weaponSkills)
        {
            if (InputManager.Instance.LeftMouse && skill.WeaponSkillCode == WeaponSkillCode.First)
            {
                skill.ActivateSkill();
            }

            if (InputManager.Instance.RightMouse && skill.WeaponSkillCode == WeaponSkillCode.Second)
            {
                skill.ActivateSkill();
            }
        }
    }
}
