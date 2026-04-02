using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<GameObject> itemList = new List<GameObject>();

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform inventoryUI;


    public void AddItem(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.AddItem(item);
        GameObject itemFrame = new GameObject();
        itemFrame.transform.position = new Vector3(-5 + inventoryUI.childCount / 10, (3.5f - inventoryUI.childCount % 10 * 0.6f), 0);
        itemFrame.transform.SetParent(inventoryUI);
        itemFrame.AddComponent<ChipItem>().Init(item, gameObject.GetComponent<InventoryToolTip>());
        itemList.Add(itemFrame);
    }

    public void RemoveItem(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.RemoveItem(item);
        Destroy(inventoryUI.Find(item.Name).gameObject);

    }

}
