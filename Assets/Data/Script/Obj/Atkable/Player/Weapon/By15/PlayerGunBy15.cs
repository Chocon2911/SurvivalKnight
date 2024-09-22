using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunBy15 : GunBy15, IDashSkillObserver
{
    [Header("Player Gun By15")]
    // Script
    [SerializeField] PlayerObjWeapon weapon;
    public PlayerObjWeapon Weapon => weapon;

    [SerializeField] protected PlayerWeaponHoldRange holdRange;
    public PlayerWeaponHoldRange HoldRange => holdRange;

    [SerializeField] protected PlayerBy15Skill_1 skill_1;
    public PlayerBy15Skill_1 Skill => skill_1;

    [SerializeField] protected PlayerBy15Skill_2 skill_2;
    public PlayerBy15Skill_2 Skill_2 => skill_2;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadHoldRange();
        this.LoadSkill_1();
        this.LoadSkill_2();
        base.LoadComponent();
        this.LoadWeapon();
    }

    protected virtual void Update()
    {
        this.PlayerShoot();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        this.RegisterDashSkillObserver();
    }

    //==========================================Gun By15==========================================
    protected override void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Obj/Equipment/Weapon/Gun/By15/Player/By15";
        this.so = Resources.Load<By15SO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    protected virtual void LoadHoldRange()
    {
        if (this.holdRange != null) return;
        this.holdRange = transform.Find("HoldRange").GetComponent<PlayerWeaponHoldRange>();
        Debug.LogWarning(transform.name + ": Load HoldRange", transform.gameObject);
    }

    protected virtual void LoadSkill_1()
    {
        if (this.skill_1 != null) return;
        this.skill_1 = transform.Find("Skill_1").GetComponent<PlayerBy15Skill_1>();
        Debug.LogWarning(transform.name + ": Load Skill_1", transform.gameObject);
    }

    protected virtual void LoadSkill_2()
    {
        if (this.skill_2 != null) return;
        this.skill_2 = transform.Find("Skill_2").GetComponent<PlayerBy15Skill_2>();
        Debug.LogWarning(transform.name + ": Load Skill_2", transform.gameObject);
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
            this.skill_1.ActivateSkill();
        }

        if (InputManager.Instance.RightMouse)
        {
            this.skill_2.ActivateSkill();
        }
    }

    //====================================Dash Skill Observer=====================================
    public void OnDashStart()
    {
        this.skill_1.gameObject.SetActive(false);
        this.skill_2.gameObject.SetActive(false);
    }

    public void OnDashFinished()
    {
        this.skill_1.gameObject.SetActive(true);
        this.skill_2.gameObject.SetActive(true);
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
