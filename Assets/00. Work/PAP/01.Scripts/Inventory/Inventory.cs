using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform inventoryUI;

    private List<GameObject> itemList = new List<GameObject>();
    private InventoryToolTip tooltip;

    private void Awake()
    {
        tooltip = GetComponent<InventoryToolTip>();
    }
    public void AddItem(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.AddItem(item);
        GameObject itemFrame = Instantiate(itemPrefab);
        itemFrame.transform.position = new Vector3(-5 + inventoryUI.childCount / 10, (3.5f - inventoryUI.childCount % 10 * 0.6f), 0);
        itemFrame.transform.SetParent(inventoryUI);
        itemFrame.GetComponent<ChipItem>().Init(item, tooltip);
        itemList.Add(itemFrame);
    }

    public void RemoveItem(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.RemoveItem(item);
        Destroy(inventoryUI.Find(item.Name).gameObject);

    }

}
