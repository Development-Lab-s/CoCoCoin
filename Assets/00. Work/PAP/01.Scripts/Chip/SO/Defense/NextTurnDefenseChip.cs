using UnityEngine;

[CreateAssetMenu(fileName = "NextTurnDefenseChip", menuName = "ChipEncounterSO/NextTurnDefenseChip")]
public class NextTurnDefenseChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        player.GetShield(10);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        StatusEffect status = new NextTurnDefense();
        player.statusEffectHandler.AddStatusEffect(status, 1);
    }
}
