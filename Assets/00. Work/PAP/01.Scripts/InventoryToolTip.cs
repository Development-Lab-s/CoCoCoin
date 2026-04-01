using TMPro;
using UnityEngine;

public class InventoryToolTip : MonoBehaviour
{
    [SerializeField] private GameObject toolTipUI;


    public void ShowToolTip(string itemName, string itemDescription)
    {
        toolTipUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = $"{itemName}";
        toolTipUI.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>().text = $"{itemDescription}";
        toolTipUI.SetActive(true);
        toolTipUI.transform.position = Input.mousePosition;
    }

    public void HideToolTip()
    {
        toolTipUI.SetActive(false);
    }
}
