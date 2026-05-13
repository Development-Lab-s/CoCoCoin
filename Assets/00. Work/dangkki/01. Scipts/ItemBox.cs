using System;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;

    public InventoryItemSO item {get; private set;}
    public GameObject dragGhost;
    private Canvas rootcanvas;

    private void Awake()
    {
        rootcanvas = GetComponentInParent<Canvas>();
    }

    public void Setup(InventoryItemSO itemData)
    {
        item = itemData;
        iconImage.sprite = itemData.Sprite;
        nameText.text = itemData.rarity.ToString();
        switch (itemData.rarity.ToString())
        {
            case "Common":
                nameText.color = Color.white;
                break;
            case "Rare":
                nameText.color = Color.green;
                break;
            case "Legendary":
                nameText.color = Color.yellow;
                break;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragGhost = new GameObject("DragGhost");
        dragGhost.transform.SetParent(rootcanvas.transform, false);
        dragGhost.transform.SetAsLastSibling();
        Image img = dragGhost.AddComponent<Image>();
        img.sprite = iconImage.sprite;
        img.raycastTarget = false;

        RectTransform rect = dragGhost.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(100, 100);

        iconImage.color = new Color(1, 1, 1, 0.4f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rootcanvas.GetComponent<RectTransform>(),
            eventData.position,
            rootcanvas.worldCamera,
            out Vector2 localPoint
        );
        dragGhost.GetComponent<RectTransform>().localPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(dragGhost);
        iconImage.color = Color.white;
    }

    public void OnDestroy()
    {
        if (dragGhost != null)
            Destroy(dragGhost);
    }
}

