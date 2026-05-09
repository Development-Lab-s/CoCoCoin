using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectHandler : MonoBehaviour
{
    public List<StatusEffect> nowStatusEffectList = new List<StatusEffect>();
    [SerializeField] private GameObject statusEffectUIPrefab;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    public void AddStatusEffect(StatusEffect status,int setTurn)
    {
        StatusEffect nowStatus = status;
        StatusEffect removeStatus = null;
        foreach (StatusEffect effect in nowStatusEffectList)
        {
            if (effect.GetType() == status.GetType())
            {
                removeStatus = effect;
                effect.statusEffectUI.Destroy();
                nowStatus.power = effect.power;
            }
        }
        if (removeStatus != null)
            nowStatusEffectList.Remove(removeStatus);
        GameObject statusEffectUI = Instantiate(statusEffectUIPrefab, transform);
        StatusEffect statusEffect = status;
        statusEffect.statusEffectUI = statusEffectUI.GetComponent<StatusEffectUI>();
        statusEffect.Init(setTurn,player,enemy);

        nowStatusEffectList.Add(statusEffect);
    }

    public void AddCount(StatusEffect status, int turn)
    {
        status.AddTurn(turn);
    }
}

