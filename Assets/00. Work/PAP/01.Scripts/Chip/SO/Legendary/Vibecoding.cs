using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Vibecoding", menuName = "ChipEncounterSO/Vibecoding")]
public class Vibecoding : ChipEncounter
{
    [SerializeField] private GameObject effectObj;

    public override void HeadChip(Player player, Enemy enemy)
    {
        Instantiate(effectObj, Vector3.zero, Quaternion.identity);
        DamageMultiplyStay effect = new DamageMultiplyStay();
        player.statusEffectHandler.AddStatusEffect(effect,1);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        Instantiate(effectObj, Vector3.zero, Quaternion.identity);
        HalfDamageMultiplyStay effect = new HalfDamageMultiplyStay();
        player.statusEffectHandler.AddStatusEffect(effect,1);
    }
}
