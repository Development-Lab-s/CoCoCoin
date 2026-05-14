using UnityEngine;

[CreateAssetMenu(fileName = "TurnDefenseMinusChip", menuName = "ChipEncounterSO/TurnDefenseMinusChip")]
public class TurnDefenseMinusChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        StatusEffect status = new TurnDefenseMinus();
        player.GetShield(20);
        player.statusEffectHandler.AddStatusEffect(status, 1);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        StatusEffect status = new TurnDefense();
        player.statusEffectHandler.AddStatusEffect(status, 1);
    }
}
