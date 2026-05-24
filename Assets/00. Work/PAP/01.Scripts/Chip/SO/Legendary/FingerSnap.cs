using UnityEngine;

[CreateAssetMenu(fileName = "FingerSnap", menuName = "ChipEncounterSO/FingerSnap")]
public class FingerSnap : ChipEncounter
{
    [SerializeField] private GameObject effect;

    public override void HeadChip(Player player, Enemy enemy)
    {
        Instantiate(effect, Vector3.zero, Quaternion.identity);
        enemy.TakeDamage(enemy.EnemyCurrentHP()/2);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        Instantiate(effect, Vector3.zero, Quaternion.identity);
        player.TakeDamage(GameData.instance.playerCurrentHp/2);
    }
}
