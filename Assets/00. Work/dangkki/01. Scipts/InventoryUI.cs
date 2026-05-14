using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySO inventorySO;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject itemSlotPrefab;

    void Start()
    {
        ScrollView();
    }

    public void ScrollView()
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);


        foreach (InventoryItemSO item in inventorySO.inventoryItemList)
        {
            var slot = Instantiate(itemSlotPrefab, content);
            slot.GetComponent<ItemBox>().Setup(item);
        }
    }
}
