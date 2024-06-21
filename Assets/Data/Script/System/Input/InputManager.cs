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

    [SerializeField] protected bool dash;
    public bool Dash => dash;
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

    protected virtual void FixedUpdate()
    {
        this.GetMoveDir();
    }

    protected virtual void Update()
    {
        this.GetDash();
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

    protected virtual void GetDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space)) this.dash = true;
        else this.dash = false;
    }
    #endregion
}
