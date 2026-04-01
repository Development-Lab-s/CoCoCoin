using UnityEngine;

public class GetChip : MonoBehaviour
{
    public void AddChip()
    {
        InventoryManager.instance.AddChip(new Chip(), 1);
    }

    public void RemoveChip()
    {
        InventoryManager.instance.RemoveChip(new Chip(), 1);
    }
}
