using UnityEngine;

[CreateAssetMenu(fileName = "SaveDefenseChip", menuName = "ChipEncounterSO/SaveDefenseChip")]
public class SaveDefenseChip : ChipEncounter
{
    public override void HeadChip(Player player, Enemy enemy)
    {
        player.GetShield(7);
        StatusEffect status = new SaveDefense();
        player.statusEffectHandler.AddStatusEffect(status, 1);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
