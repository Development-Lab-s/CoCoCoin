using UnityEngine;

[CreateAssetMenu(fileName = "AttackPerDefenseChip", menuName = "ChipEncounterSO/AttackPerDefenseChip")]
public class AttackPerDefenseChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        DamageHandler.CalculateDamage(player,enemy,player.shieldHP);
        player.DiscardShield(player.shieldHP);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        StatusEffect status = new AttackPerDefense();
        player.statusEffectHandler.AddStatusEffect(status, 1);
    }
}
