using System;
using UnityEngine;

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
        
    }
}
