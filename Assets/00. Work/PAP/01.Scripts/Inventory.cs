using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> itemList = new List<GameObject>();

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform inventoryUI;


    public void AddItem(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.AddItem(item);
        GameObject itemFrame = Instantiate(itemPrefab, inventoryUI);
        itemFrame.GetComponent<Chip>().Init(item,gameObject.GetComponent<InventoryToolTip>());
        itemList.Add(itemFrame);
    }

    public void RemoveItem(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.RemoveItem(item);
    }
}
