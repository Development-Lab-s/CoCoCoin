using UnityEngine;

public class RemoveCombo : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "SaveCombo";
        leftTurns = 2;
        textColor = new Color(1f, 0.1f, 0.8f);
        contents = $"턴 종료시 콤보 제거";
    }

    public override void OnStartTurn(Player player, Enemy enemy)
    {
        player.combo.ResetCombo();
    }
}
