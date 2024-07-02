using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotgun : ShootSkill
{
    [Header("Player Shotgun")]
    [Header("Script")]
    [SerializeField] protected PlayerObjManager manager;
    public PlayerObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadManager();
        base.LoadComponent();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponentInChildren<PlayerObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //========================================Shoot Skill=========================================
    protected override void LoadMainObj()
    {
        this.mainObj = this.manager.transform;
    }

    protected override void DoShoot()
    {
        base.DoShoot();
        
        Vector3 targetPos = GameManager.Instance.MousePos;
    }
}
