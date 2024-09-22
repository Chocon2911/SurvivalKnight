using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/Obj/AtkObj/Enemy")]
public class EnemySO : AtkObjSO
{
    public float Health;
    public float ChaseSpeed;
    public List<ItemDropByRate> DropList;
}
