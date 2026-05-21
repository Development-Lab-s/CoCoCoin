using UnityEngine;

public class DamageMultiplyStay : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        leftTurns = 1;
        textColor = new Color(1f, 0.3f, 0f);
        contents = $"피해 2배";
    }

    public override void OnAttack(int normalVal, out int target)
    {
        target = normalVal * 2;
    }
}
