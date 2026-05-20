using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DomainExpansion", menuName = "ChipEncounterSO/DomainExpansion")]
public class DomainExpansion : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        List<InventoryItemSO> a = new List<InventoryItemSO>(BattleManager.instance.nowChips);
        foreach (InventoryItemSO item in a)
        {
            BattleManager.instance.DiscardChip(item,BattleManager.instance.chipModels[(BattleManager.instance.nowChips.IndexOf(item))]);
        }
        BattleManager.instance.DrawChip();
        Power status = new Power();
        for (int i = 0; i < 77; i++)
        {
            player.statusEffectHandler.AddStatusEffect(status,77);
        }   
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        DamageSevenMore status = new DamageSevenMore();
        player.statusEffectHandler.AddStatusEffect(status,1);
    }
}
