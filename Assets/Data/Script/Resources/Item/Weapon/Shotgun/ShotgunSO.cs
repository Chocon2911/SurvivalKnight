using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "SO/ItemDrop/Weapon/Shotgun")]
public class ShotgunSO : ItemDropSO
{
    public List<ItemShotgun> UpgradeLevels;
}
