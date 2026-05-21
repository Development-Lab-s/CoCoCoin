using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Vibecoding", menuName = "ChipEncounterSO/Vibecoding")]
public class Vibecoding : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageMultiplyStay effect = new DamageMultiplyStay();
        player.statusEffectHandler.AddStatusEffect(effect,1);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        HalfDamageMultiplyStay effect = new HalfDamageMultiplyStay();
        player.statusEffectHandler.AddStatusEffect(effect,1);
    }
}
