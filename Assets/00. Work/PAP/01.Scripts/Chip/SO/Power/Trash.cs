using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Trash", menuName = "ChipEncounterSO/Trash")]
public class Trash : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 20);
        BattleManager.instance.isLocked = true;
        BattleManager.instance.needDiscard = BattleManager.instance.nowChips.Count;
        if (BattleManager.instance.needDiscard <= 0)
        {
            BattleManager.instance.isLocked = false;
        }
        BattleManager.instance.AmountDrawMax += BattleManager.instance.needDiscard;
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        Power status = new Power();
        for (int i = 0; i < 5; i++)
        {
            player.statusEffectHandler.AddStatusEffect(status,77);
        }   
    }
}
