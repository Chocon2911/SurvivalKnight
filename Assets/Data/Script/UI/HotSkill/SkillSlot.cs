using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : HuyMonoBehaviour
{
    [Header("Skill Slot")]
    [Header("Other")]
    [SerializeField] protected Transform selectedUIObj;
    public Transform SelectedUIObj => selectedUIObj;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSelectedUIObj();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSelectedUIObj()
    {
        if (this.selectedUIObj != null) return;
        this.selectedUIObj = transform.Find("Selected");
        Debug.LogWarning(transform.name + ": Load SelectedUIObj", transform.gameObject);
    }
}
