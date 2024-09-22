using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunM4 : GunM4, IDashSkillObserver
{
    [Header("Player Gun M4")]
    // Script
    [SerializeField] protected PlayerObjWeapon weapon;
    public PlayerObjWeapon Weapon => weapon;

    [SerializeField] protected PlayerWeaponHoldRange holdRange;
    public PlayerWeaponHoldRange HoldRange => holdRange;

    [SerializeField] protected PlayerM4Skill_1 skill1;
    public PlayerM4Skill_1 Skill1 => skill1;

    [SerializeField] protected PlayerM4Skill_2 skill2;
    public PlayerM4Skill_2 Skill2 => skill2;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapon();
        this.LoadHoldRange();
        this.LoadSkill1();
        this.LoadSkill2();
    }

    protected virtual void Update()
    {
        this.PlayerShoot();
    }

    protected virtual void Start()
    {
        this.RegisterDashSkillObserver();
    }

    //===========================================Gun M4===========================================
    protected override void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Obj/Equipment/Weapon/Gun/M4/Player/M4";
        this.so = Resources.Load<M4SO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    //=======================================Load Component=======================================
    // Script
    protected virtual void LoadWeapon()
    {
        if (this.weapon != null) return;
        this.weapon = transform.parent.GetComponent<PlayerObjWeapon>();
        Debug.LogWarning(transform.name + ": Load Weapon", transform.gameObject);
    }

    protected virtual void LoadHoldRange()
    {
        if (this.holdRange != null) return;
        this.holdRange = transform.Find("HoldRange").GetComponent<PlayerWeaponHoldRange>();
        Debug.LogWarning(transform.name + ": Load HoldRange", transform.gameObject);
    }

    protected virtual void LoadSkill1()
    {
        if (this.skill1 != null) return;
        this.skill1 = transform.Find("Skill_1").GetComponent<PlayerM4Skill_1>();
        Debug.LogWarning(transform.name + ": Load Skill1", transform.gameObject);
    }

    protected virtual void LoadSkill2()
    {
        if (this.skill2 != null) return;
        this.skill2 = transform.Find("Skill_2").GetComponent<PlayerM4Skill_2>();
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

    //====================================Dash Skill Observer=====================================
    public void OnDashStart()
    {
        this.skill1.gameObject.SetActive(false);
        this.skill2.gameObject.SetActive(false);    }

    public void OnDashFinished()
    {
        this.skill1.gameObject.SetActive(true);
        this.skill2.gameObject.SetActive(true);
    }

    protected virtual void RegisterDashSkillObserver()
    {
        this.weapon.Manager.Skill.Dash.AddObserver(this);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();

        if (this.so == null)
        {
            Debug.LogError(transform.name + ": so is null", transform.gameObject);
            return;
        }

        this.ObjName = this.so.ObjName;
        this.holdRange.HoldRad = this.so.HoldRange;
    }
}
