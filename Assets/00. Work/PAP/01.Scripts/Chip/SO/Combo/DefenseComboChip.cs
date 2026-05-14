using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DefenseComboChip", menuName = "ChipEncounterSO/DefenseComboChip")]
public class DefenseComboChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        player.GetShield(7*2);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
