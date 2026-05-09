using DG.DemiLib;
using UnityEngine;
using UnityEngine.EventSystems;

public class UseChipArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (!BattleManager.instance.isLocked && BattleManager.instance.canUse)
        {
            BattleManager.instance.DiscardChip(eventData.pointerDrag.GetComponent<ChipDraw>().chip, eventData.pointerDrag);
            BattleManager.instance.UseChip(eventData.pointerDrag.GetComponent<ChipDraw>().chip);
        }
    }
}
