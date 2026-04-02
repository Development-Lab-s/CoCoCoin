using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemSO", menuName = "Scriptable Objects/InventoryItemSO")]
public class InventoryItemSO : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public Sprite SpriteOnInventory;
    public event Action Ability;
    public void Test(Action ee)
    {
        Ability += ee;
    }
    public void Test1()
    {
        Ability?.Invoke();
    }
    public void Test2(Action ee)
    {
        Ability -= ee;
    }

}


