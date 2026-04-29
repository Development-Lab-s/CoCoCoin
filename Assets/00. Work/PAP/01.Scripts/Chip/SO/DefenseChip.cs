using UnityEngine;

[CreateAssetMenu(fileName = "DefenseChip", menuName = "ChipEncounterSO/DefenseChip")]
public class DefenseChip : ChipEncounter
{
    public int power;
    public override void HeadChip(Player player, Enemy enemy)
    {
        player.GetShield(power);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
    }
}
