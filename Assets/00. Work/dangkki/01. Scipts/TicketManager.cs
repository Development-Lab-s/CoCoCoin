using UnityEngine;

public class TicketManager : MonoBehaviour
{
    public static TicketManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public int _ticket = 0;
    public int _spins = 0;
    public void AddTicket(int amount)
    {
        _ticket += amount;
        Debug.Log($"추가 티켓 개수 : {amount} 현재 티켓 수 : {_ticket}");
    }

    public void AddSpins(int amount)
    {
        _spins += amount;
        Debug.Log($"추가 시도 횟수 : {amount} 현제 시도 횟수 :  {_spins}");
    }
}
