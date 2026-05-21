using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardChipArea : MonoBehaviour,IDropHandler
{
    [SerializeField] private LeftMotionHandler leftMotionHandler;
    [SerializeField] private InventorySO inventory;
    public void OnDrop(PointerEventData eventData)
    {
        if (BattleManager.instance.needDiscard > 0)
        {
            InventoryItemSO item = eventData.pointerDrag.GetComponent<ChipDraw>().chip;
            if (BattleManager.instance.isReplicated)
            {
                BattleManager.instance.drawChips.Add(item);
                inventory.inventoryItemList.Add(item);
            }
            BattleManager.instance.DiscardChip(item, eventData.pointerDrag);
            BattleManager.instance.needDiscard -= 1;
            if (BattleManager.instance.needDiscard <= 0)
            {
                leftMotionHandler.PlayMotion(1);
                BattleManager.instance.isLocked = false;
            }
        }
    }
}
