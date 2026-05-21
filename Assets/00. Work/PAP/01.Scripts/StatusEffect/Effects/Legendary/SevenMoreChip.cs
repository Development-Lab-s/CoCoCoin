using UnityEngine;
public class SevenMoreChip : StatusEffect
{
    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "SevenMoreChip";
        leftTurns = 1;
        textColor = new Color(1, 1, 0);
        contents = $"다음 칩을 7번 사용함";
    }
    
}
