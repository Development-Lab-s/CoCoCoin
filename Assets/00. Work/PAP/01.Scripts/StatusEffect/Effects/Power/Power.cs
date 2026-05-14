using UnityEngine;

public class Power : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        power += 1;
        leftTurns = 77;
        textColor = new Color(1f, 0f, 0f);
        contents = $"피해량 + {power}";
    }

    public override void Minus()
    {
        power = Mathf.Max(power -1, 0);
        leftTurns = 77;
        contents = $"피해량 + {power}";
    }

    public override void OnAttack(int normalVal, out int target)
    {
        target = normalVal + power;
    }
}
