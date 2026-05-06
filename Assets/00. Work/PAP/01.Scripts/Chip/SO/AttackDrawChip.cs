using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackDrawChip", menuName = "ChipEncounterSO/AttackDrawChip")]
public class AttackDrawChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 10);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        for (int i = 0; i < 2; i++)
        {
            BattleManager.instance.DrawChip();
        }
    }
}
