using Unity.Jobs;
using UnityEngine;

[CreateAssetMenu(fileName = "DiscardChip", menuName = "ChipEncounterSO/DiscardChip")]
public class DiscardChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        for (int i = 0; i < 2; i++)
        {
            BattleManager.instance.DrawChip();
        }
        BattleManager.instance.isLocked = true;
        BattleManager.instance.needDiscard += Mathf.Clamp(1,0, BattleManager.instance.nowChips.Count);
        if (BattleManager.instance.needDiscard <= 0)
        {
            BattleManager.instance.isLocked = false;
        }
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
