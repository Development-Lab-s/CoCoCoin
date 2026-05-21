using System;
using System.Collections;
using _00._Work.PAP._01.Scripts;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(fileName = "BbangHuman", menuName = "ChipEncounterSO/BbangHuman")]
public class BbangHuman : ChipEncounter
{
    [SerializeField] private GameObject effect;
    public override void HeadChip(Player player, Enemy enemy)
    {
        Instantiate(effect, Vector3.zero, Quaternion.identity);
        CoroutineRunner.instance.StartCoroutine(StartDamage());
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        for (int i = 0; i < 2; i++)
        {
            if (BattleManager.instance.drawChips.Count > 0)
            {
                InventoryItemSO item =
                    BattleManager.instance.drawChips[UnityEngine.Random.Range(0, BattleManager.instance.drawChips.Count)];
                BattleManager.instance.drawChips.Remove(item);
                BattleManager.instance.inventory.inventoryItemList.Remove(item);
            }
        }
    }

    IEnumerator StartDamage()
    {
        yield return new WaitForSeconds(0.5f);
        BattleManager.instance.isLocked = true;
        BattleManager.instance.isReplicated = true;
        BattleManager.instance.needDiscard += Mathf.Clamp(1,0, BattleManager.instance.nowChips.Count);
        if (BattleManager.instance.needDiscard <= 0)
        {
            BattleManager.instance.isLocked = false;
        }
    }
}
