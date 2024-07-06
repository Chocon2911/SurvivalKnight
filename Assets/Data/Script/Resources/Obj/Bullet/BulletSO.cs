using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "SO/Obj/Bullet")]
public class BulletSO : ObjSO
{
    public float FlySpeed;
    //Despawn
    public float ExistTime;
    //Damage Sender
    public float Damage;
    public AtkObjType CanDamageType;
}
