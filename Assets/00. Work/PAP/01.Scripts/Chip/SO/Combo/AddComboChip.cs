using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AddComboChip", menuName = "ChipEncounterSO/AddComboChip")]
public class AddComboChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        player.combo.SetCombo(2);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
