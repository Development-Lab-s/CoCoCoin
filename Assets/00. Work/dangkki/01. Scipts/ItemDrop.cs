using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    InventoryUI inventoryUI;
    ItemBox itemBox;

    public void OnDrop(PointerEventData eventData)
    {
        ItemBox slot = eventData.pointerDrag?.GetComponent<ItemBox>();
        if (slot == null) return;
        if (slot.item.rarity == InventoryItemSO.Rarity.Common)
            TicketManager.instance.AddSpins(1);
        else if (slot.item.rarity == InventoryItemSO.Rarity.Rare)
            TicketManager.instance.AddSpins(3);
        else if (slot.item.rarity == InventoryItemSO.Rarity.Legendary)
            TicketManager.instance.AddSpins(10);
        ItemManager.instance._inventory.inventoryItemList.Remove(slot.item);
        Destroy(slot.gameObject);


    }
}
