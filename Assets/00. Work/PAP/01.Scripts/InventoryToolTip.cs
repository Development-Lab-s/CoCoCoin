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

    private void Awake()
    {
        itemNameUI = toolTipUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        itemDescriptionUI = toolTipUI.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>();
        itemSprite = toolTipUI.transform.Find("ItemImage").GetComponent<Image>();

    }

    public void ShowToolTip(string itemName, string itemDescription, Vector2 chipTrm, Sprite sprite)
    {
        RectTransform rectTrm = toolTipUI.GetComponent<RectTransform>();
        itemNameUI.text = $"{itemName}";
        itemDescriptionUI.text = $"{itemDescription}";
        itemSprite.sprite = sprite;
        toolTipUI.SetActive(true);
        rectTrm.position = chipTrm;
    }

    public void HideToolTip()
    {
        toolTipUI.SetActive(false);
    }
}
