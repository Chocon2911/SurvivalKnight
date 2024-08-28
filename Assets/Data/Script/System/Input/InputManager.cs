using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : HuyMonoBehaviour
{
    #region Variable
    [Header("Input Manager")]
    private static InputManager instance;
    public static InputManager Instance => instance;

    [Header("Stat")]
    [SerializeField] protected Vector2 moveDir;
    public Vector2 MoveDir => moveDir;

    [SerializeField] protected int numberPressed;
    public int NumberPressed => numberPressed;

    [SerializeField] protected bool dash;
    public bool Dash => dash;

    [SerializeField] protected bool leftMouse;
    public bool LeftMouse => leftMouse;

    [SerializeField] protected bool rightMouse;
    public bool RightMouse => rightMouse;
    #endregion



    #region Unity
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One InputManager Only", transform.gameObject);
            return;
        }

        instance = this;
        this.DefaultStat();
    }

    protected virtual void Update()
    {
        this.GetMoveDir();
        this.GetNumberPressed();
        this.GetDash();
        this.GetMouse();
    }
    #endregion



    #region Get
    //============================================Get=============================================
    protected virtual void GetMoveDir()
    {
        this.moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) this.moveDir.x = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) this.moveDir.x = 1;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) this.moveDir.y = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) this.moveDir.y = -1;
    }

    protected virtual void GetNumberPressed()
    {
        if (Input.GetKey(KeyCode.Alpha0)) this.numberPressed = 0;
        else if (Input.GetKey(KeyCode.Alpha1)) this.numberPressed = 1;
        else if (Input.GetKey(KeyCode.Alpha2)) this.numberPressed = 2;
        else if (Input.GetKey(KeyCode.Alpha3)) this.numberPressed = 3;
        else if (Input.GetKey(KeyCode.Alpha4)) this.numberPressed = 4;
        else if (Input.GetKey(KeyCode.Alpha5)) this.numberPressed = 5;
        else if (Input.GetKey(KeyCode.Alpha6)) this.numberPressed = 6;
        else if (Input.GetKey(KeyCode.Alpha7)) this.numberPressed = 7;
        else if (Input.GetKey(KeyCode.Alpha8)) this.numberPressed = 8;
        else if (Input.GetKey(KeyCode.Alpha9)) this.numberPressed = 9;
        else this.numberPressed = 10;
    }

    protected virtual void GetDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)) this.dash = true;
        else this.dash = false;
    }

    protected virtual void GetMouse()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0))
        {
            this.leftMouse = true;
        }
        else this.leftMouse = false;

        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKey(KeyCode.Mouse1))
        {
            this.rightMouse = true;
        }
        else this.rightMouse = false;
    }
    #endregion

    #region Other
    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.numberPressed = 1;
    }
    #endregion
}
