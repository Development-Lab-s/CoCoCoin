using UnityEngine;
public class TurnMultiplierDefense : StatusEffect
{
    public override void Setting(Player player, Enemy enemy)
    {
        power = 2;
        leftTurns = 1;
        textColor = new Color(0.5f, 0.5f, 1f);
        contents = $"쉴드 2배";
    }

    public override void OnDefense(int normalVal, out int target)
    {
        target = normalVal * power;
    }
}
