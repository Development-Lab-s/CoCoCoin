using UnityEngine;

[CreateAssetMenu(fileName = "MultiplierDefenseChip", menuName = "ChipEncounterSO/MultiplierDefenseChip")]
public class MultiplierDefenseChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        player.GetShield(player.shieldHP);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        StatusEffect status = new TurnMultiplierDefense();
        player.statusEffectHandler.AddStatusEffect(status, 1);
    }
}       
