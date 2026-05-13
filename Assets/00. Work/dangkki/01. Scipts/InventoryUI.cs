using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySO inventorySO;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private InventoryItemSO[] inventoryItems;

    void Start()
    {
        ScrollView();
    }

    public void ScrollView()
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);


        foreach (var item in inventorySO.inventoryItemList)
        {
            var slot = Instantiate(itemSlotPrefab, content);
            slot.GetComponent<ItemBox>().Setup(item);
        }
    }
}
