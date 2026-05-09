using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveComboChip", menuName = "ChipEncounterSO/SaveComboChip")]
public class SaveComboChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        StatusEffect status = new SaveCombo();
        player.statusEffectHandler.AddStatusEffect(status,77);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        player.combo.SetCombo(2);
    }
}
