using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BeatCoin", menuName = "ChipEncounterSO/BeatCoin")]
public class BeatCoin : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 10);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
