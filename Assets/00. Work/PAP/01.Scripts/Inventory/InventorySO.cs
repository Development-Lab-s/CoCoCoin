using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "Scriptable Objects/InventorySO")]
public class InventorySO : ScriptableObject
{
    private void OnEnable() {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
    public List<InventoryItemSO> inventoryItemList;
}
