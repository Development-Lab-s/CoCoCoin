using System;
using System.Collections;
using System.Collections.Generic;
using _00._Work.PAP._01.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "DomainExpansion", menuName = "ChipEncounterSO/DomainExpansion")]
public class DomainExpansion : ChipEncounter
{
    [SerializeField] private GameObject effect;
    public override void HeadChip(Player player, Enemy enemy)
    {
        Instantiate(effect, Vector3.zero, Quaternion.identity);
        CoroutineRunner.instance.StartCoroutine(StartDamage(player, enemy, BattleManager.instance.nowChips.Count * 20));
        List<InventoryItemSO> a = new List<InventoryItemSO>(BattleManager.instance.nowChips);
        foreach (InventoryItemSO item in a)
        {
            BattleManager.instance.DiscardChip(item,BattleManager.instance.chipModels[(BattleManager.instance.nowChips.IndexOf(item))]);
        }
    }

    IEnumerator StartDamage(Player player,Enemy enemy,int damage)
    {
        yield return new WaitForSeconds(0.5f);
        DamageHandler.CalculateDamage(player,enemy,damage);
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        foreach (InventoryItemSO item in BattleManager.instance.nowChips )
        {
            BattleManager.instance.inventory.inventoryItemList.Remove(item);
        }
        BattleManager.instance.nowChips.Clear();
        foreach (GameObject gameObject in BattleManager.instance.chipModels)
        {
            Destroy(gameObject);
        }
        BattleManager.instance.chipModels.Clear();
        BattleManager.instance.ChangeNowChips();
    }
}
