using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjWeapon : PlayerObjAbstract
{
    [SerializeField] protected List<BaseWeapon> weapons;
    public List<BaseWeapon> Weapons => weapons;
}
