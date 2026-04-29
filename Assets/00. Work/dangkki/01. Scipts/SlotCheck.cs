using UnityEngine;

public class SlotCheck : MonoBehaviour
{
    SlotMachine1 _slotMachine;

    [SerializeField] Transform _slot0;
    [SerializeField] Transform _slot1;
    [SerializeField] Transform _slot2;
     public TicketManager _ticketManager;



    private void Awake()
    {
        _slotMachine = GetComponent<SlotMachine1>();
        //_ticketManager = GetComponent<TicketManager>();
    }
    private void Update()
    {
        //_slot0.GetChild(_slot0.childCount - 1);
    }

    public void CheckSlot()
    {
        if (_slot0.GetChild(_slot0.childCount - 2).name == _slot1.GetChild(_slot1.childCount - 2).name &&
         _slot0.GetChild(_slot0.childCount - 2).name == _slot2.GetChild(_slot2.childCount - 2).name)
        {
            if (_slot0.GetChild(_slot0.childCount - 2).name == "Bell")
            {
                _ticketManager.AddTicket(20);
            }
            else if (_slot0.GetChild(_slot0.childCount - 2).name == "Cherry")
            {
                _ticketManager.AddTicket(30);
            }
            else if (_slot0.GetChild(_slot0.childCount - 2).name == "JackPot")
            {
                _ticketManager.AddTicket(50);
            }
        }
    }

}
