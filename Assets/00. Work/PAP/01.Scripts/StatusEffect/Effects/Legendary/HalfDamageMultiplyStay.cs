using UnityEngine;

public class HalfDamageMultiplyStay : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        leftTurns = 1;
        textColor = new Color(1f, 0.3f, 0f);
        contents = $"피해 1/2배";
    }

    public override void OnAttack(int normalVal, out int target)
    {
        target = (int)(normalVal * 0.5f);
    }
}
