using UnityEngine;

[CreateAssetMenu(fileName = "DefenseAttackChip", menuName = "ChipEncounterSO/DefenseAttackChip")]
public class DefenseAttackChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player,enemy,player.shieldHP);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
