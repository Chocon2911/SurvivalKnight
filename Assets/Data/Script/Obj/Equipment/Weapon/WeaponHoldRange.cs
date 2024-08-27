using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHoldRange : HuyMonoBehaviour
{
    [Header("Weapon Hold Range")]
    //Other
    [SerializeField] protected Transform mainObj;
    public Transform MainObj => mainObj;

    [SerializeField] protected Transform targetObj;
    public Transform TargetObj => targetObj;

    // Script
    [SerializeField] protected BaseWeapon baseWeapon;
    public BaseWeapon BaseWeapon => baseWeapon;

    // Stat
    public float HoldRad;

    [SerializeField] protected bool isFlipped;
    public bool IsFlipped => isFlipped;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadbaseWeapon();
    }

    protected virtual void Update()
    {
        this.UpdateWeaponPos();
        this.UpdateModelRot();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadbaseWeapon()
    {
        if (this.baseWeapon != null) return;
        this.baseWeapon = transform.parent.GetComponent<BaseWeapon>();
        Debug.LogWarning(transform.name + ": Load BaseWeapon", transform.gameObject);
    }

    //==========================================Get Set===========================================
    // Set
    protected virtual void SetMainObj(Transform mainObj)
    {
        this.mainObj = mainObj;
    }

    protected virtual void SetTargetObj(Transform targetObj)
    {
        this.targetObj = targetObj;
    }

    // Get
    protected virtual Vector3 GetDir()
    {
        if (this.targetObj == null || this.mainObj == null) return Vector3.zero;

        Vector3 dir = (this.targetObj.position - this.mainObj.position).normalized;
        return dir;
    }

    protected virtual float GetAngle(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;
    }

    //=========================================Hold Range=========================================
    protected virtual void UpdateWeaponPos()
    {
        Vector3 dir = this.GetDir();
        float angle = this.GetAngle(dir);
        Vector3 newPos = dir * this.HoldRad;
        Vector3 newRot = new Vector3(0, 0, angle);

        //Debug.Log(newPos + " " + angle + " " + dir, transform.gameObject);
        this.baseWeapon.transform.SetLocalPositionAndRotation(newPos, Quaternion.Euler(newRot));
    }

    protected virtual void UpdateModelRot()
    {
        float angle = this.baseWeapon.transform.localRotation.eulerAngles.z;
        float xRot = 0;
        float yRot = this.baseWeapon.Model.transform.localRotation.eulerAngles.y;
        float zRot = this.baseWeapon.Model.transform.localRotation.eulerAngles.z;

        if ((angle < 90 || angle > 270) && this.isFlipped)
        {
            xRot = 180;
            this.isFlipped = false;
        }

        else if ((angle >= 90 && angle <= 270) && !this.isFlipped)
        {
            xRot = 180;
            this.isFlipped = true;
        }

        this.baseWeapon.Model.transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }
}
