using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class InventoryToolTip : MonoBehaviour
{
    [SerializeField] private GameObject toolTipUI;
    private TextMeshProUGUI itemNameUI;
    private TextMeshProUGUI itemDescriptionUI;
    private Image itemSprite;
    Dictionary<InventoryItemSO.Rarity,Color> rarityColors = new Dictionary<InventoryItemSO.Rarity, Color>()
    {
        {InventoryItemSO.Rarity.Common, new Color32(255, 255, 255, 255) },
        {InventoryItemSO.Rarity.Rare, new Color32(150, 200, 255, 255) },
        {InventoryItemSO.Rarity.Legendary, new Color32(255, 255, 50, 255) },

    };

    private void Awake()
    {
        itemNameUI = toolTipUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        itemDescriptionUI = toolTipUI.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>();
        itemSprite = toolTipUI.transform.Find("ItemImage").GetComponent<Image>();
        
    }

    private void Start()
    {
        toolTipUI.SetActive(false);
    }

    public void ShowToolTip(string itemName, string itemDescription, Vector2 chipTrm, Sprite sprite, InventoryItemSO.Rarity rarity)
    {
        RectTransform rectTrm = toolTipUI.GetComponent<RectTransform>();
        itemNameUI.text = $"{itemName}";
        itemNameUI.color = rarityColors[rarity];
        itemDescriptionUI.text = $"{itemDescription}";
        itemSprite.sprite = sprite;
        toolTipUI.SetActive(true);
        if (chipTrm != Vector2.zero)
        {
            rectTrm.position = chipTrm;
        }
    }

    public void HideToolTip()
    {
        toolTipUI.SetActive(false);
    }
}
