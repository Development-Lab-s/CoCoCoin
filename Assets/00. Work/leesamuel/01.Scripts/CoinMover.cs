using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CoinMover : MonoBehaviour
{
    public void Select(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.AddItem(item);
    }
}
