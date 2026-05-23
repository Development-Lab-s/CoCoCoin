using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Jackpot", menuName = "ChipEncounterSO/Jackpot")]
public class Jackpot : ChipEncounter
{
    [SerializeField] private GameObject effect;

    public override void HeadChip(Player player, Enemy enemy)
    {
        Instantiate(effect, Vector3.zero, Quaternion.identity);
        SevenMoreChip status = new SevenMoreChip();
        player.statusEffectHandler.AddStatusEffect(status,1);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        SevenLeftDeath status = new SevenLeftDeath();
        player.statusEffectHandler.AddStatusEffect(status,7);
    }
}
