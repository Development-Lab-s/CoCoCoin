using System;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(fileName = "BbangHuman", menuName = "ChipEncounterSO/BbangHuman")]
public class BbangHuman : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        BattleManager.instance.isLocked = true;
        BattleManager.instance.isReplicated = true;
        BattleManager.instance.needDiscard += Mathf.Clamp(1,0, BattleManager.instance.nowChips.Count);
        if (BattleManager.instance.needDiscard <= 0)
        {
            BattleManager.instance.isLocked = false;
        }
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        for (int i = 0; i < 2; i++)
        {
            if (BattleManager.instance.drawChips.Count > 0)
            {
                InventoryItemSO item =
                    BattleManager.instance.drawChips[UnityEngine.Random.Range(0, BattleManager.instance.drawChips.Count)];
                BattleManager.instance.drawChips.Remove(item);
                BattleManager.instance.inventory.inventoryItemList.Remove(item);
            }
        }
    }
}
