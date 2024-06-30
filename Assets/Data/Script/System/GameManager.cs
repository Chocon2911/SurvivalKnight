using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : HuyMonoBehaviour
{
    [Header("Game Manager")]
    private static GameManager instance;
    public static GameManager Instance => instance;

    [Header("Stat")]
    [SerializeField] protected Vector3 mousePos;
    public Vector3 MousePos => mousePos;

    //===========================================Unity============================================
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One GameManager Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    protected virtual void FixedUpdate()
    {
        this.GetMousePos();
    }

    //============================================Get=============================================
    protected virtual void GetMousePos()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
    }
}
