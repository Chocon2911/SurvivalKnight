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

    [SerializeField] protected PlayerShotgunM4 skill2;
    public PlayerShotgunM4 Skill2 => skill2;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapon();
        this.LoadSkill1();
        this.LoadSkill2();
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

    protected virtual void LoadSkill1()
    {
        if (this.skill1 != null) return;
        this.skill1 = transform.Find("Skill_1").GetComponent<PlayerSingleShootM4>();
        Debug.LogWarning(transform.name + ": Load Skill1", transform.gameObject);
    }

    protected virtual void LoadSkill2()
    {
        if (this.skill2 != null) return;
        this.skill2 = transform.Find("Skill_2").GetComponent<PlayerShotgunM4>();
        Debug.LogWarning(transform.name + ": Load Skill2", transform.gameObject);
    }

    //========================================Player Shoot========================================
    protected virtual void PlayerShoot()
    {
        if (InputManager.Instance.LeftMouse)
        {
            this.skill1.ActivateSkill();
        }

        if (InputManager.Instance.RightMouse)
        {
            this.skill2.ActivateSkill();
        }
    }
}
