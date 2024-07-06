using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevel : HuyMonoBehaviour
{
    [Header("Base Level")]
    [Header("Stat")]
    [SerializeField] protected int currLevel;
    public int CurrLevel => currLevel;

    [SerializeField] protected int maxLevel;
    public int MaxLevel => maxLevel;

    [SerializeField] protected int minLevel;
    public int MinLevel => minLevel;

    //===========================================Level============================================
    protected virtual void LevelUp()
    {
        if (this.currLevel >= this.maxLevel) return;
        this.currLevel += 1;
    }

    protected virtual void DeLevel()
    {
        if (this.currLevel <= minLevel) return; 
        this.currLevel -= 1;
    }    
}
