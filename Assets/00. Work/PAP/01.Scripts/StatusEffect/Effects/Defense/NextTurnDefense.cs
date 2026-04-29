using UnityEngine;
public class NextTurnDefense : StatusEffect
{
    public override void Setting(Player player, Enemy enemy)
    {
        power += player.shieldHP/2;
        leftTurns = 1;
        textColor = new Color(0.9f, 0.8f, 1f);
        contents = $"다음턴 쉴드 +{power}";
    }

    public override void OnStartTurn(Player player, Enemy enemy)
    {
        player.GetShield(power);
    }
}
