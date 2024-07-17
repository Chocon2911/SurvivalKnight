using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjSkill : PlayerObjAbstract
{
    [Header("Player Obj Skill")]
    [Header("Script")]
    [SerializeField] protected List<CharacterSkill> skills;
    public List<CharacterSkill> Skills => skills;

    [Header("Stat")]
    [SerializeField] protected int maxSkillAmount;
    public int MaxSkillAmount => maxSkillAmount;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSkills();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSkills()
    {
        if (this.skills.Count > 0) return;
        foreach (CharacterSkill skill in transform)
        {
            if (this.skills.Count >= this.maxSkillAmount)
            {
                skill.transform.gameObject.SetActive(false);
                break;
            }
            this.skills.Add(skill);
        }

        if (this.skills.Count == 0) return;
        Debug.LogWarning(transform.name + ": Load Skills", transform.gameObject);
    }
}
