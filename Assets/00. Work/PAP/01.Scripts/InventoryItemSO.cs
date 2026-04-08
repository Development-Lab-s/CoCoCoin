using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemSO", menuName = "Scriptable Objects/InventoryItemSO")]
public class InventoryItemSO : ScriptableObject
{
    public string Name;
    [TextArea] public string Description;
    public Sprite Sprite;
    public Sprite SpriteOnInventory;
    public ChipEncounter ChipEncounter;

}


