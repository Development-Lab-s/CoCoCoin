using TMPro;
using UnityEngine;

public class InventoryToolTip : MonoBehaviour
{
    [SerializeField] private GameObject toolTipUI;


    public void ShowToolTip(string itemName, string itemDescription, Vector2 chipTrm, Sprite sprite)
    {
        RectTransform rectTrm = toolTipUI.GetComponent<RectTransform>();
        toolTipUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = $"{itemName}";
        toolTipUI.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>().text = $"{itemDescription}";
        toolTipUI.transform.Find("ItemImage").GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        toolTipUI.SetActive(true);
        rectTrm.position = (Vector3)chipTrm - new Vector3(0,toolTipUI.GetComponent<RectTransform>().rect.height,0) - new Vector3(0,100,0);
    }

    public void HideToolTip()
    {
        toolTipUI.SetActive(false);
    }
}
