using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CheckChipList : MonoBehaviour
{
    [SerializeField] Transform currentChips;
    [SerializeField] GameObject itemChipPrefab;
    [SerializeField] InventoryToolTip toolTip;
    [SerializeField] RectTransform moveModelRTrm;
    [SerializeField] private InventorySO inventoryData;

    private Vector3 moveModelOriginPos;
    private Vector3 moveModelNewPos;

    private Vector2 startPos = new Vector2(-439, 237);

    private bool openActive = true;

    private bool nowOpened = false;

    [SerializeField] private bool isBattle = true;


    private void Start()
    {
        
        moveModelOriginPos = moveModelRTrm.position;
        moveModelNewPos = moveModelRTrm.position + Camera.main.ViewportToWorldPoint(new Vector3(0.5f,2f,0f));
        moveModelRTrm.gameObject.SetActive(false);
    }

    public void AddChip(InventoryItemSO item,bool isTransparency)
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
        if (isTransparency)
        {
            itemChip.GetComponent<ChipItem>().image.color = new Color(0.5f, 0.5f, 0.5f, 0.9f);
        }
    }

    public void ClearChip()
    {
        foreach (Transform item in currentChips.GetComponentsInChildren<Transform>())
        {
            if (item.CompareTag("ChipItem"))
            {
                Destroy(item.gameObject);
            }
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
            moveModelRTrm.DOMove(moveModelNewPos, 0.5f).OnComplete(() => { openActive = true; moveModelRTrm.gameObject.SetActive(false); moveModelRTrm.position = moveModelOriginPos; ClearChip(); });
        }
        else
        {
            SettingChips();
            moveModelRTrm.position = moveModelNewPos;
            moveModelRTrm.gameObject.SetActive(true);
            nowOpened = true;
            moveModelRTrm.DOMove(moveModelOriginPos, 0.5f).OnComplete(() => openActive = true);
        }
     }

    private void SettingChips()
    {
        if (isBattle)
        {
            foreach (InventoryItemSO item in BattleManager.instance.drawChips)
            {
                AddChip(item, false);
            }

            foreach (InventoryItemSO item in BattleManager.instance.discardChips)
            {
                AddChip(item, true);
            }

            foreach (InventoryItemSO item in BattleManager.instance.nowChips)
            {
                AddChip(item, true);
            }
        }
        else
        {
            foreach (InventoryItemSO item in inventoryData.inventoryItemList) 
            {
                AddChip(item, false);
            }
        }

    }
}
