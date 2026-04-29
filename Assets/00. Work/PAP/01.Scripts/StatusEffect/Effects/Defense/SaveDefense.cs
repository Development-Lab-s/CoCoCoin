using UnityEngine;

public class SaveDefense : StatusEffect
{
    
    public override void Setting(Player player, Enemy enemy)
    {
        checkValue = "SaveDefense";
        leftTurns = 1;
        textColor = new Color(0.25f, 0.25f, 1f);
        contents = $"턴 종료시 쉴드 유지";
    }
}
