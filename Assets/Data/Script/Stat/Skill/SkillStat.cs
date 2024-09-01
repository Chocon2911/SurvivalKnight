using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillStat : BaseStat
{
    [Header("Skill Stat")]
    public float CooldownDelay;
    public float ChargeDelay;
    public float DoingTime;
}
