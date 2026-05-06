using UnityEngine;

public class SaveCombo : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "SaveCombo";
        leftTurns = 77;
        textColor = new Color(1f, 0.1f, 0.8f);
        contents = $"콤보 끊김을 막아줍니다.";
    }
}
