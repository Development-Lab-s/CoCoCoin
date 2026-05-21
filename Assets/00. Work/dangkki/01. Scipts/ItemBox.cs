using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;

    public InventoryItemSO item {get; private set;}
    public GameObject dragGhost;
    private Canvas rootcanvas;
    public Canvas shopCanvas;
    
    

    private void Awake()
    {
        rootcanvas = GetComponentInParent<Canvas>();
    }

    public void Setup(InventoryItemSO itemData)
    {
        item = itemData;
        iconImage.sprite = itemData.Sprite;
        nameText.text = itemData.Name.ToString();
        switch (itemData.rarity.ToString())
        {
            case "Common":
                nameText.color = Color.white;
                break;
            case "Rare":
                nameText.color = Color.cyan;
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
        img.preserveAspect = true;
        img.sprite = iconImage.sprite;
        img.raycastTarget = false;

        RectTransform rect = dragGhost.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(220, 220);

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Descripton.instance.OnHover();
        Descripton.instance.SetSlotDes(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Descripton.instance.OnExit();
    }
}

