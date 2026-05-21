using UnityEngine;

[CreateAssetMenu(fileName = "DevlabChip", menuName = "ChipEncounterSO/DevlabChip")]
public class DevlabChip : ChipEncounter
{

    public override void HeadChip(Player player, Enemy enemy)
    {

    }

    public override void TailChip(Player player, Enemy enemy)
    {
        player.combo.SetCombo(10);
        SceneManageHandler.instance.MoveScene(7);
    }
}
