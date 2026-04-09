using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private InventorySO inventorySO;

    public void AddItem(InventoryItemSO item)
    {
        inventorySO.inventoryItemList.Add(item);
    }

    public void RemoveItem(InventoryItemSO item)
    {
        inventorySO.inventoryItemList.Remove(item);
       
    }

    public void ClearItem()
    {
        inventorySO.inventoryItemList.Clear();
    }

}
