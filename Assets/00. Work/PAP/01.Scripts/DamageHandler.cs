using UnityEngine;

public class DamageHandler 
{
    
    public static void CalculateDamage(Player plr, Enemy enemy, int damage)
    {
        enemy.TakeDamage((int)(damage * plr.combo.ReturnComboCount()));
    }
}
