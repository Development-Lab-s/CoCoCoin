using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultChip", menuName = "Scriptable Objects/DefaultChip")]
public class DefaultChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player, enemy, 5);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        player.GetShield(5);
    }
}
