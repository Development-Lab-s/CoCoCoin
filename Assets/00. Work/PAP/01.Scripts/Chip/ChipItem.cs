using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryItemSO item;
    private InventoryToolTip toolTip;
    private Image image;
    private RectTransform rectTransform;
    private Vector3 originalPosition;
    private Vector3 newPosition;


    public void Init(InventoryItemSO item,InventoryToolTip toolTip)
    {
        rectTransform = GetComponent<RectTransform>();
        this.item = item;
        this.toolTip = toolTip;
        originalPosition = rectTransform.position;
        newPosition = rectTransform.position + new Vector3(0,15f);
        image = GetComponent<Image>();
        image.sprite = item.SpriteOnInventory;
        gameObject.name = item.Name;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.DOMove(newPosition, 0.2f);
        Vector2 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        toolTip.ShowToolTip(item.Name, item.Description, Vector2.zero, item.Sprite);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOMove(originalPosition, 0.2f);
        toolTip.HideToolTip();
    }
}
