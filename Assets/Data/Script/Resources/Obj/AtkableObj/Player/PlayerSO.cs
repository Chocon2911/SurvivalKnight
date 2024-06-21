using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerObjSO", menuName = "SO/Obj/AtkableObj/player")]
public class PlayerSO : AtkableObjSO
{
    public float Satiety;
    public float DashSpeed;
    public float DashCooldown;
    public float DashTime;
}
