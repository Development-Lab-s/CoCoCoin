using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardChipArea : MonoBehaviour,IDropHandler
{
    [SerializeField] private LeftMotionHandler leftMotionHandler;
    public void OnDrop(PointerEventData eventData)
    {
        if (BattleManager.instance.needDiscard > 0)
        {
            BattleManager.instance.DiscardChip(eventData.pointerDrag.GetComponent<ChipDraw>().chip, eventData.pointerDrag);
            BattleManager.instance.needDiscard -= 1;
            if (BattleManager.instance.needDiscard <= 0)
            {
                leftMotionHandler.PlayMotion(1);
                BattleManager.instance.isLocked = false;
            }
        }
    }
}
