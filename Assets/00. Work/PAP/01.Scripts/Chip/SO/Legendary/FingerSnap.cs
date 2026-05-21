using UnityEngine;

[CreateAssetMenu(fileName = "FingerSnap", menuName = "ChipEncounterSO/FingerSnap")]
public class FingerSnap : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {
        enemy.TakeDamage(enemy.EnemyCurrentHP()/2);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        player.TakeDamage(GameData.instance.playerCurrentHp/2);
    }
}
