using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerObjSO", menuName = "SO/Obj/AtkableObj/player")]
public class PlayerSO : AtkableObjSO
{
    [Header("Player")]
    public float Satiety;
    //Dash
    [Header("Dash")]
    public float DashSpeed;
    public float DashCooldown;
    public float DashChargeTime;
    public float DashTime;
    //Shoot
    [Header("Shoot")]
    public string BulletName;
    public float BulletSpeed;
    public float ShootCooldown;
    public float ShootChargeTime;
    public float ShootTime;
    public float BulletAppearRad;
    //Shotgun
    [Header("Shotgun")]
    public string ShotgunBulletName;
    public float ShotgunBulletSpeed;
    public float ShotgunCooldown;
    public float ShotgunChargeTime;
    public float ShotgunTime;
    public int ShotgunPelletAmount;
    public float ShotgunBulletAppearRad;
}
