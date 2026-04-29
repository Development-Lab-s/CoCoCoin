using UnityEngine;

public class ReturnDefense : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "ReturnDefense";
        leftTurns = 1;
        textColor = new Color(1f, 0.1f, 0.8f);
        contents = $"막은 피해만큼 반격";
    }
}
