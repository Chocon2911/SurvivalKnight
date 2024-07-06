using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotSkillCtrl : HuyMonoBehaviour
{
    [Header("UI Hot Skill Ctrl")]
    [Header("Script")]
    [SerializeField] protected UIHotSkillManager manager;
    public UIHotSkillManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    protected virtual void Update()
    {
        this.SelectSlot();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<UIHotSkillManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //========================================Select Slot=========================================
    protected virtual void SelectSlot()
    {
        int numberPressed = InputManager.Instance.NumberPressed;
        if (numberPressed >= 10 || numberPressed > this.manager.SkillSlots.Count || numberPressed <= 0) return;
        this.TurnOffAllSelect();
        this.manager.SkillSlots[numberPressed - 1].SelectedUIObj.gameObject.SetActive(true);
    }

    protected virtual void TurnOffAllSelect()
    {
        foreach(SkillSlot skillSlot in this.manager.SkillSlots)
        {
            skillSlot.SelectedUIObj.gameObject.SetActive(false);
        }
    }
}
