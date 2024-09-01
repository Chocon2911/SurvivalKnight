using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSingleShoot : SingleShootSkill
{
    [Header("Player Single Shoot Skill")]
    // Script
    [SerializeField] protected PlayerObjWeapon playerObjWeapon;
    public PlayerObjWeapon PlayerObjWeapon => playerObjWeapon;



    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjWeapon();
    }

    protected virtual void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null in OnEnable");
            return;
        }

        this.SetMainObj(this.playerObjWeapon.Manager.transform);
        this.SetTargetObj(GameManager.Instance.MouseObj);
    }

    //=======================================Load Component=======================================
    // Script
    protected virtual void LoadPlayerObjWeapon()
    {
        if (this.playerObjWeapon != null) return;
        this.playerObjWeapon = transform.parent.parent.GetComponent<PlayerObjWeapon>();
        Debug.LogWarning(transform.name + ": Load PlayerObjWeapon", transform.gameObject);
    }
}
