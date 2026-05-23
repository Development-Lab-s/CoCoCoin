using UnityEngine;

public class SlotCheck : MonoBehaviour
{
    public static SlotCheck instance;
    SlotMachine1 _slotMachine;

    [SerializeField] Transform _slot0;
    [SerializeField] Transform _slot1;
    [SerializeField] Transform _slot2;
    [SerializeField] private InventorySO inventory;
    [SerializeField] private InventoryItemSO jackpotItem;
    TicketManager _ticketManager;



    private void Awake()
    {
        if (instance == null) { 
        instance = this;
        }
        _slotMachine = GetComponent<SlotMachine1>();
    }
    public void CheckSlot()
    {
        string Slot0 = _slot0.GetChild(_slot0.childCount - 2).name;
        string Slot1 = _slot1.GetChild(_slot0.childCount - 2).name;
        string Slot2 = _slot2.GetChild(_slot0.childCount - 2).name;
        if (Slot0 == Slot1 &&
         Slot0 == Slot2)
        { 
            switch(Slot0)
            {
                case "Bell":
                    TicketManager.instance.AddTicket(25);
                    break;
                case "Cherry":
                    TicketManager.instance.AddTicket(35);
                    break;
                case "JackPot":
                    TicketManager.instance.AddTicket(999);
                    inventory.inventoryItemList.Add(jackpotItem);
                    break;
            }
        }
        else if (Slot0 == Slot1 ||Slot0 == Slot2 || Slot1 == Slot2)
        {
            if (true)
                TicketManager.instance.AddTicket(4);
            else 
                TicketManager.instance.AddTicket(2);
        }
        else
        {
            TicketManager.instance.AddTicket(1);
        }
        }

}
