using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDropSO", menuName = "SO/ItemDrop/Null")]
public class ItemDropSO : ScriptableObject
{
    public ItemDropType Type;
    public int DefaultAmount;
}
