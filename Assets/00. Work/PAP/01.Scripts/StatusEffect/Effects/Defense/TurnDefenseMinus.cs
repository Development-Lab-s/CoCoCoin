using UnityEngine;

public class TurnDefenseMinus : StatusEffect
{
    public override void Setting(Player player, Enemy enemy)
    {
        power += 5;
        leftTurns = 1;
        textColor = new Color(0.5f, 0.5f, 1f);
        contents = $"칩을 쓸때마다 쉴드 - {power}";
    }

    public override void OnUse(Player player, Enemy enemy)
    {
        player.DiscardShield(power);
    }
}
