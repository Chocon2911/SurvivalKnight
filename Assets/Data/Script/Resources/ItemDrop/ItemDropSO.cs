using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDrop", menuName = "SO/ItemDrop")]
public class ItemDropSO : ScriptableObject
{
    public string ItemName;
    public ItemType ItemType;
    public ItemCode ItemCode;
}
