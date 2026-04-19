using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckChipList : MonoBehaviour
{
    [SerializeField] CanvasGroup listUIGroup;
    [SerializeField] Transform currentChips;
    [SerializeField] GameObject itemChipPrefab;
    [SerializeField] InventoryToolTip toolTip;
    [SerializeField] RectTransform moveModelRTrm;

    private Vector3 moveModelOriginPos;
    private Vector3 moveModelNewPos;

    private Vector2 startPos = new Vector2(150, -54);

    private bool openActive = true;

    private bool nowOpened = false;

    private Dictionary<InventoryItemSO, GameObject> inventoryItems;

    public enum chipStatus { Draw, Now, Discard }


    private void Start()
    {
        moveModelOriginPos = moveModelRTrm.position;
        moveModelNewPos = moveModelRTrm.position + Camera.main.ViewportToScreenPoint(Vector3.up);
        moveModelRTrm.gameObject.SetActive(false);
    }

    public void AddChip(InventoryItemSO item)
    {
        GameObject itemChip = Instantiate(itemChipPrefab,currentChips);
        Vector2 targetPos = startPos;
        float addX = 0f;
        switch ((currentChips.childCount - 1) / 14)
        {
            case 0:
                addX = -4.25f;
                break;
            case 1:
                targetPos += new Vector2(146,0);
                addX = -3f;
                break;
            case 2:
                targetPos += new Vector2(725, 0);
                addX = 2.5f;
                break;
            case 3:
                targetPos += new Vector2(872, 0);
                addX = 3.75f;
                break;
            default:
                Debug.LogWarning("The number of chips you have is out of the range.");
                break;
        }
        targetPos += new Vector2(addX * ((currentChips.childCount - 1) % 14), -28.5f * ((currentChips.childCount - 1) % 14));
        itemChip.GetComponent<RectTransform>().anchoredPosition = targetPos;
        itemChip.GetComponent<ChipItem>().Init(item, toolTip);
    }

    public void ChangeStatus(InventoryItemSO item,chipStatus status)
    {
        if (status == chipStatus.Draw)
        {

        }
    }


    public void OpenClose()
    {
        if (!openActive)
            return;
        openActive = false;
        if (nowOpened)
        {
            nowOpened = false;
            moveModelRTrm.DOMove(moveModelNewPos, 0.5f).OnComplete(() => { openActive = true; moveModelRTrm.gameObject.SetActive(false); moveModelRTrm.position = moveModelOriginPos;  });
        }
        else
        {
            moveModelRTrm.position = moveModelNewPos;
            moveModelRTrm.gameObject.SetActive(true);
            nowOpened = true;
            moveModelRTrm.DOMove(moveModelOriginPos, 0.5f).OnComplete(() => openActive = true);
        }
     }
}
