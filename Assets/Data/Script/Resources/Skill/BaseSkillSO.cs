using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkillSO : ScriptableObject
{
    [Header("Skill SO")]
    public float CooldownDelay;
    public float ChargingDelay;
    public float DoingTime;
}
