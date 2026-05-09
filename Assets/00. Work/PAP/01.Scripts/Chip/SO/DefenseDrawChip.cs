using UnityEngine;

[CreateAssetMenu(fileName = "DefenseDrawChip", menuName = "ChipEncounterSO/DefenseDrawChip")]
public class DefenseDrawChip : ChipEncounter
{
    public int power;
    public override void HeadChip(Player player, Enemy enemy)
    {
        player.GetShield(power);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        for (int i = 0; i < 2; i++)
        {
            BattleManager.instance.DrawChip();
        }
    }
}
