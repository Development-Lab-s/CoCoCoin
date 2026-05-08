using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ComboDrawChip", menuName = "ChipEncounterSO/ComboDrawChip")]
public class ComboDrawChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        player.combo.SetCombo(1);
        BattleManager.instance.DrawChip();
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
