using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChipEncounter", menuName = "Scriptable Objects/ChipEncounter")]
public abstract class ChipEncounter : ScriptableObject
{
    public int headChance = 50;

    public virtual void Initialize() { }

    public virtual void FlipCoin() 
    {
        int randomValue = UnityEngine.Random.Range(0, 100);
        if (randomValue < headChance)
        {
            HeadChip();
        }
        else
        {
            TailChip();
        }
    }



    public abstract void HeadChip();

    public abstract void TailChip();
}
