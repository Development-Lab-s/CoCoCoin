using UnityEngine;

public class DamageHandler 
{
    
    public static void CalculateDamage(Player plr, Enemy enemy, int damage)
    {
        int fixedDamage = damage;
        foreach (StatusEffect statusEffect in plr.statusEffectHandler.nowStatusEffectList)
        {
            statusEffect.OnAttack(damage, out damage);
        }
        plr.statusEffectHandler.nowStatusEffectList.RemoveAll(effect => effect.leftTurns <= 0);
        enemy.TakeDamage((int)(damage * plr.combo.ReturnComboCount()));
    }
}
