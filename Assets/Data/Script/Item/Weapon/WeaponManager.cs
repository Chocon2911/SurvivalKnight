using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponManager : HuyMonoBehaviour
{
    [Header("Weapon Manager")]
    [Header("Other")]
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [SerializeField] protected List<WeaponSkill> skills;
    public List<WeaponSkill> Skills => skills;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadSkills();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    protected virtual void LoadSkills()
    {
        if (this.skills.Count > 0) return;
        foreach(Transform child in transform)
        {
            WeaponSkill weaponSkill = child.GetComponent<WeaponSkill>();

            if (weaponSkill == null) continue;
            this.skills.Add(weaponSkill);
        }

        Debug.LogWarning(transform.name + ": Load SKills", transform.gameObject);
    }
}
