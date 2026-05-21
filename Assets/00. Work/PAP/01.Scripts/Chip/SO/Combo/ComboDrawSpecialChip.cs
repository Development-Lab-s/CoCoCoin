using System.Collections.Generic;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Chip.SO.Combo
{
    [CreateAssetMenu(fileName = "ComboDrawSpecialChip", menuName = "ChipEncounterSO/ComboDrawSpecialChip")]
    public class ComboDrawSpecialChip : ChipEncounter
    {
        public override void HeadChip(Player player, Enemy enemy)
        {
            for (int i = 0; i < player.combo.currentCombo; i++)
            {
                BattleManager.instance.DrawChip();
            }
        }

        public override void TailChip(Player player, Enemy enemy)
        {
            player.combo.SetCombo(BattleManager.instance.nowChips.Count);
            List<InventoryItemSO> a = new List<InventoryItemSO>(BattleManager.instance.nowChips);
            foreach (InventoryItemSO item in a)
            {
                BattleManager.instance.DiscardChip(item,BattleManager.instance.chipModels[(BattleManager.instance.nowChips.IndexOf(item))]);
            }
        }
    }
}