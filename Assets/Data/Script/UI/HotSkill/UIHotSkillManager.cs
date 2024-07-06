using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotSkillManager : HuyMonoBehaviour
{
    [Header("UI Hot Skill Manager")]
    [Header("Script")]
    [SerializeField] protected List<SkillSlot> skillSlots;
    public List<SkillSlot> SkillSlots => skillSlots;

    [SerializeField] protected UIHotSkillCtrl ctrl;
    public UIHotSkillCtrl Ctrl => ctrl;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSkillSlots();
        this.LoadCtrl();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSkillSlots()
    {
        if (this.skillSlots.Count > 0) return;

        Transform grid = transform.Find("Grid");
        foreach (Transform skillSlotObj in grid)
        {
            SkillSlot skillSlot = skillSlotObj.transform.GetComponent<SkillSlot>();
            if (skillSlot == null)
            {
                Debug.LogError(transform.name + ": skillSlot is null", transform.gameObject);
                continue;
            }

            skillSlots.Add(skillSlot);
        }

        Debug.LogWarning(transform.name + ": Load SkillSlots", transform.gameObject);
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponent<UIHotSkillCtrl>();
        Debug.LogWarning(transform.name + ": Load Ctrl", transform.gameObject);
    }
}
