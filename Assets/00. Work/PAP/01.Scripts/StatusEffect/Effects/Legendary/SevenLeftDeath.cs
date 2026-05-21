using UnityEngine;
public class SevenLeftDeath : StatusEffect
{
    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "Death";
        leftTurns = 7;
        textColor = new Color(1, 0, 0);
        contents = $"사망까지..";
    }
    
}
