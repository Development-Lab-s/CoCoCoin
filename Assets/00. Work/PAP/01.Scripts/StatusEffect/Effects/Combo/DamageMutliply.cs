using UnityEngine;

public class DamageMutliply : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "DamageMutliply";
        leftTurns = 77;
        textColor = new Color(1f, 0.1f, 0.8f);
        contents = $"피해 2배";
    }

    public override void OnAttack(int normalVal, out int target)
    {
        target = normalVal * 2;
        AddTurn(-77);
    }
}
