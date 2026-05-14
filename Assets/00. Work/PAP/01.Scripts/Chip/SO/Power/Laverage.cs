using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Laverage", menuName = "ChipEncounterSO/Laverage")]
public class Laverage : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 25);
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
        StatusEffect status = player.statusEffectHandler.nowStatusEffectList.Find(x => x is Power);
        if (status != null)
        {
            for (int i = 0; i < status.power; i++)
            {
                StatusEffect status1 = new Power();
                player.statusEffectHandler.AddStatusEffect(status1, 77);
            }   
        }
    }
}
