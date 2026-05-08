using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackChip", menuName = "ChipEncounterSO/AttackChip")]
public class AttackChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 7);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
