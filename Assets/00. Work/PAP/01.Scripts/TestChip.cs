using UnityEngine;

public class GetChip : MonoBehaviour
{
    [SerializeField] private InventoryItemSO item;
    [SerializeField] private Inventory inventory;

    public void AddChip()
    {
        inventory.AddItem(item);
    }


    public void RemoveChip()
    {
        inventory.RemoveItem(item);
    }

}
