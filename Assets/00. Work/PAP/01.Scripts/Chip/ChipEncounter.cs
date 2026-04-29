using System;
using UnityEngine;
using static InventoryItemSO;

[CreateAssetMenu(fileName = "ChipEncounter", menuName = "Scriptable Objects/ChipEncounter")]
public abstract class ChipEncounter : ScriptableObject
{
    public enum Type
    {
        Queueable,
        Stop,
    }
    public int headChance = 50;
    public int headChipMotion = 0;
    public int tailChipMotion = 0;
    public Type type;

    public virtual void Initialize() { }

    public virtual bool FlipCoin(Player player, Enemy enemy) 
    {
        int randomValue = UnityEngine.Random.Range(0, 100);
        return randomValue < (headChance);
    }

    public abstract void HeadChip(Player player, Enemy enemy);

    public abstract void TailChip(Player player, Enemy enemy);


}