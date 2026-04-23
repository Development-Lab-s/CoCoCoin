using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChipEncounter", menuName = "Scriptable Objects/ChipEncounter")]
public abstract class ChipEncounter : ScriptableObject
{
    public int headChance = 50;
    public int headChipMotion = 0;
    public int tailChipMotion = 0;


    public virtual void Initialize() { }

    public virtual bool FlipCoin(Player player, Enemy enemy, MotionHandler motion) 
    {
        int randomValue = UnityEngine.Random.Range(0, 100);
        motion.PlayMotion(randomValue < headChance, player,enemy, this, headChipMotion, tailChipMotion);
        return randomValue < headChance;
    }

    public abstract void HeadChip(Player player, Enemy enemy);

    public abstract void TailChip(Player player, Enemy enemy);


}