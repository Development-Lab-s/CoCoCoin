using UnityEngine;
public class DamageSevenMore : StatusEffect
{
    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "DamageSeven";
        leftTurns = 1;
        textColor = new Color(1, 0, 0);
        contents = $"받는피해 X7";
    }
    
}
