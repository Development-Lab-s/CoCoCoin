using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

[CreateAssetMenu(fileName = "WhiteChip", menuName = "ChipEncounterSO/WhiteChip")]
public class WhiteChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        for (int i = 0; i < BattleManager.instance.AmountDrawMax; i++)
        {
            BattleManager.instance.DrawChip();
        }
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        BattleManager.instance.AmountDrawMax += BattleManager.instance.nowChips.Count;
        List<InventoryItemSO> a = new List<InventoryItemSO>(BattleManager.instance.nowChips);
        foreach (InventoryItemSO item in a)
        {
            BattleManager.instance.DiscardChip(item,BattleManager.instance.chipModels[(BattleManager.instance.nowChips.IndexOf(item))]);
        }
    }
}
