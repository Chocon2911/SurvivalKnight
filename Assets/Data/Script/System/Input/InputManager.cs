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
    [SerializeField] protected Vector4 moveDir;
    public Vector4 MoveDir => moveDir;

    [SerializeField] protected int numberPressed;
    public int NumberPressed => numberPressed;

    [SerializeField] protected bool dash;
    public bool Dash => dash;

    [SerializeField] protected bool shoot;
    public bool Shoot => shoot;
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
        base.Awake();
    }

    protected virtual void Update()
    {
        this.GetMoveDir();
        this.GetNumberPressed();
        this.GetDash();
        this.GetShoot();
    }
    #endregion



    #region Get
    //============================================Get=============================================
    protected virtual void GetMoveDir()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) this.moveDir.z = 1;
        else this.moveDir.z = 0;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) this.moveDir.x = 1;
        else this.moveDir.x = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) this.moveDir.y = 1;
        else this.moveDir.y = 0;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) this.moveDir.w = 1;
        else this.moveDir.w = 0;
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

    protected virtual void GetShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0)) this.shoot = true;
        else this.shoot = false;
    }
    #endregion
}
