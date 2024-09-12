using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBurst : BurstSkill
{
    [Header("Player Burst Skill")]
    // Script
    [SerializeField] protected PlayerObjWeapon playerObjWeapon;
    public PlayerObjWeapon PlayerWeapon => playerObjWeapon;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadPlayerObjWeapon();
        base.LoadComponent();
    }

    protected virtual void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null in OnEnable", transform.gameObject);
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
