using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HuyMonoBehaviour : MonoBehaviour
{
    protected virtual void ResetValue()
    {
        //For override
    }

    protected virtual void LoadComponent()
    {
        //For override
    }

    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void Awake()
    {
        this.LoadComponent();
    }
}
