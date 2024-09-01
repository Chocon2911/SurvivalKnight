using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShotgunStat : ShootSkillStat
{
    [Header("Shotgun Stat")]
    public float SpreadRange;
    public float PelletAmount;
}
