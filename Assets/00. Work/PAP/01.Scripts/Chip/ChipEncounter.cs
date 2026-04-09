using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChipEncounter", menuName = "Scriptable Objects/ChipEncounter")]
public abstract class ChipEncounter : ScriptableObject
{
    public int headChance = 50;
    public Flip Flip;

    public virtual void Initialize() { }

    public virtual void FlipCoin(Flip flipScript) 
    {
        int randomValue = UnityEngine.Random.Range(0, 100);
        if (randomValue < headChance)
        {
            HeadChip(flipScript);
        }
        else
        {
            TailChip(flipScript);
        }
    }

    

    public abstract void HeadChip(Flip flipScript);

    public abstract void TailChip(Flip flipScript);
}
