using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerObjSO", menuName = "SO/Obj/AtkableObj/player")]
public class PlayerSO : AtkableObjSO
{
    public float Satiety;
    //Dash
    public float DashSpeed;
    public float DashCooldown;
    public float DashChargeTime;
    public float DashTime;
    //Shoot
    public string BulletName;
    public float BulletSpeed;
    public float ShootCooldown;
    public float ShootChargeTime;
    public float ShootTime;
    public float BulletAppearRad;
}
