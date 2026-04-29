using System;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.U2D.Animation;


[CreateAssetMenu(fileName = "InventoryItemSO", menuName = "Scriptable Objects/InventoryItemSO")]
public class InventoryItemSO : ScriptableObject
{
    public string Name;
    [TextArea(10,20)] public string Description;
    public Sprite Sprite;
    public Sprite SpriteOnInventory;
    public Sprite SpriteOnStack;
    public ChipEncounter ChipEncounter;
    public SpriteLibraryAsset spriteLibrary;
    public enum Rarity
    {
        Common,
        Rare,
        Legendary,
    }
    public Rarity rarity;
}


