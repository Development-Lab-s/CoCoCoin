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
        BattleManager.instance.isLocked = true;
        BattleManager.instance.needDiscard = BattleManager.instance.nowChips.Count;
        if (BattleManager.instance.needDiscard <= 0)
        {
            BattleManager.instance.isLocked = false;
        }
        BattleManager.instance.AmountDrawMax += BattleManager.instance.needDiscard;
    }
}
