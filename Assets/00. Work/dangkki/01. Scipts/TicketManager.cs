using TMPro;
using UnityEngine;

public class TicketManager : MonoBehaviour
{
    public static TicketManager instance;
    public TextMeshProUGUI TicketText;
    public TextMeshProUGUI SpinText;

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
        SetTicketText();
    }

    public void SetTicketText()
    {
        TicketText.text = $"티켓 : {_ticket.ToString()}$";
    }

    public void AddSpins(int amount)
    {
        _spins += amount;
        SetSpinText();
    }
    
    public void SetSpinText()
    {
        SpinText.text = $"스핀 횟수 : {_spins.ToString()}";
    }
}
