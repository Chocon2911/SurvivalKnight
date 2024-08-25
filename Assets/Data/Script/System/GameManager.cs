using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : HuyMonoBehaviour
{
    [Header("Game Manager")]
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected Transform mouseObj;
    public Transform MouseObj => mouseObj;

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

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMouseObj();
    }

    protected virtual void FixedUpdate()
    {
        this.GetMousePos();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadMouseObj()
    {
        if (this.mouseObj != null) return;
        this.mouseObj = transform.Find("Mouse");
        Debug.LogWarning(transform.name + ": Load MouseObj", transform.gameObject);
    }

    //============================================Get=============================================
    protected virtual void GetMousePos()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));

        if (this.mousePos == null) return;
        this.mouseObj.position = this.mousePos;
    }
}
