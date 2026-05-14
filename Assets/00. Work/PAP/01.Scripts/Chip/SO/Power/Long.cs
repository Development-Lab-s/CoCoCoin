using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Long", menuName = "ChipEncounterSO/Long")]
public class Long : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 7);
        StatusEffect status = new Power();
        player.statusEffectHandler.AddStatusEffect(status, 77);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
