using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryItemSO item;
    private Image image;
    private InventoryToolTip toolTip;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void Init(InventoryItemSO item,InventoryToolTip toolTip)
    {
        this.item = item;
        image.sprite = item.Sprite;
        this.toolTip = toolTip;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //칩 이름 & 설명 보여주기
        toolTip.ShowToolTip(item.Name, item.Description);
        Debug.Log($"이름 : {item.Name} 설명 : {item.Description}");
    }

    public void OnPointerExit(PointerEventData eventData)   
    {
        //칩 이름 & 설명 보여주기
        toolTip.HideToolTip();
        Debug.Log($"이름 : {item.Name} 설명 : {item.Description}");
    }

}
