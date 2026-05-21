using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageComboChip", menuName = "ChipEncounterSO/DamageComboChip")]
public class DamageComboChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 7 * 2);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        player.GetShield(7*2);
    }
}
