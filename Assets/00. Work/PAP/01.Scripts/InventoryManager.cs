using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    static public InventoryManager instance;

    [SerializeField] private InventorySO inventorySO;

    [SerializeField] private GameObject chipPrefab;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

    public void AddItem(InventoryItemSO item)
    {
        inventorySO.inventoryItemList.Add(item);
        SettingChip();
    }

    public void RemoveItem(InventoryItemSO item)
    {
        inventorySO.inventoryItemList.Remove(item);
        SettingChip();
    }

    public void ClearItem()
    {
        inventorySO.inventoryItemList.Clear();
        SettingChip();
    }
    public void SettingChip()
    {
        foreach (InventoryItemSO item in InventoryManager.instance.inventorySO.inventoryItemList)
        {
            GameObject chip = Instantiate(chipPrefab, transform.position, Quaternion.identity);
            chip.GetComponent<Chip>().Init(item);
        }
    }

}
