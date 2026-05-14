using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Short", menuName = "ChipEncounterSO/Short")]
public class Short : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 15);
        StatusEffect status = player.statusEffectHandler.nowStatusEffectList.Find(x => x is Power);
        if (status != null)
        {
            int count = status.power;
            for (int i = 0; i < count; i++)
            {
                player.statusEffectHandler.Discount(status);
            }
        }
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
