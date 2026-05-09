using UnityEngine;

public class TicketManager : MonoBehaviour
{
    public int _ticket = 0;
    public void AddTicket(int amount)
    {
        _ticket += amount;
        Debug.Log($"추가 티켓 개수 : {amount} 현재 티켓 수 : {_ticket}");
    }
}
