using UnityEngine;

public class SaveCombo : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "SaveCombo";
        leftTurns = 77;
        textColor = new Color(1f, 0.1f, 0.8f);
        contents = $"다음 한번, 콤보가 끊기지 않습니다";
    }
}
