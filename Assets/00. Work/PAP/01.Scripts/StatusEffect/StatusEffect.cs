using UnityEngine;
public abstract class StatusEffect
{
    
    public int leftTurns;

    public string checkValue;
    public string contents;
    public Color textColor;

    public StatusEffectUI statusEffectUI;

    public int power;


    public void Init(int turn,Player player, Enemy enemy)
    {
        leftTurns = turn;
        Setting(player,enemy);
        statusEffectUI.Init();
        statusEffectUI.UpdateUI(contents,leftTurns,textColor);
    }

    public abstract void Setting(Player player, Enemy enemy);
    
    public virtual void Minus() {power--;}

    public void AddTurn(int val)
    {
        leftTurns += val;
        statusEffectUI.UpdateUI(contents,leftTurns, textColor);
        if (leftTurns <= 0)
        {
            statusEffectUI.Destroy();
        }
    }

    public virtual void OnAttack(int normalVal, out int target) { target = normalVal; }
    
    public virtual void OnStartTurn(Player player, Enemy enemy) {}

    public virtual void OnDefense(int normalVal, out int target) { target = normalVal; }
    
    public virtual void OnUse(Player player, Enemy enemy) { }
}
