using UnityEngine;

public class AttackPerDefense : StatusEffect
{

    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "AttackPerDefense";
        leftTurns = 1;
        textColor = new Color(1f, 0.5f, 0.8f);
        contents = $"방어 할때 계수 만큼 공격";
    }

    public override void OnDefense(int normalVal, out int target)
    {
        BattleManager.instance.enemy.TakeDamage(normalVal);
        target = normalVal;
    }
}
