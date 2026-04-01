using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class GetChip : MonoBehaviour
{
    [SerializeField] private InventoryItemSO item;

    public void AddChip()
    {
        InventoryManager.instance.AddItem(item);
    }


    public void RemoveChip()
    {
        InventoryManager.instance.RemoveItem(item);
    }

}
