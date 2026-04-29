using UnityEngine;

[CreateAssetMenu(fileName = "ReturnDefenseChip", menuName = "ChipEncounterSO/ReturnDefenseChip")]
public class ReturnDefenseChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        player.GetShield(7);
        StatusEffect status = new ReturnDefense();
        player.statusEffectHandler.AddStatusEffect(status, 1);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
