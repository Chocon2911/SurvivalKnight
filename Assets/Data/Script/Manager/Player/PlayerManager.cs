using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : HuyMonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance => instance;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("One PlayerManager Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }
}
