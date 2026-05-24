using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using NUnit.Framework;

public class TicketManager : MonoBehaviour
{
    public static TicketManager instance;
    public TextMeshProUGUI TicketText;
    public TextMeshProUGUI SpinText;
    
    private float TicketCurrentY;
    private float SpinCurrentY;

    private void Awake()
    {
        TicketCurrentY = TicketText.GetComponent<RectTransform>().anchoredPosition.y;
        SpinCurrentY = SpinText.GetComponent<RectTransform>().anchoredPosition.y;
        if (instance == null)
        {
            instance = this;
        }
    }
    public int _ticket = 0;
    public int _spins = 0;
    private int Remember;
    private int test;
    private int ReRemember;
    
    public void AddTicket(int amount)
    {
        _ticket = test;
        _ticket += amount;
        Remember =  amount;
        SetTicketText(false);
    }
    public void UseTicket(int amount)
    {
            _ticket = test;
            _ticket -= amount;
            Remember =  amount;
            SetTicketText(true);
    }

    public void SetTicketText(bool Use)
    {
        float Value;
        Color color;
        if (Use == false)
        {
            Value = 30f;
            color = Color.yellow;
        }
        else
        {
            Value = -30f;
            color = Color.red;
        }

        int Loop = Remember / 10;
            TicketText.rectTransform.DOAnchorPosY(TicketCurrentY + Value, 0.1f)
                .SetEase(Ease.OutBack)
                .OnStepComplete(() =>
                {

                    if (Loop > 0)
                    {
                        Loop--;
                        if (Use == false)
                            test += 10;
                        else
                            test -= 10;
                    }
                    else
                    {
                        if (Use == false)
                            test++;
                        else
                            test--;
                    }
                    Debug.Log(test);
                    TicketText.text = $"티켓 : {test}$";
                }).OnComplete(() =>
                {
                    TicketText.rectTransform.DOAnchorPosY(TicketCurrentY, 0.1f);
                }).SetLoops(Loop + Remember % 10, LoopType.Yoyo);
            TicketText.DOColor(color, 0.1f).SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    TicketText.DOColor(Color.white, 0.1f);
                }).SetLoops(Loop + Remember % 10, LoopType.Yoyo);
    }

    public void AddSpins(int amount)
    {
        ReRemember =  amount;
        SetSpinText(false);
    }
    
    public void SetSpinText(Boolean Use)
    {
        float Value;
        Color color;
        if (Use == false)
        {
            Value = 10f;
            color = Color.yellow;
        }
        else
        {
            Value = -10f;
            color = Color.red;
            ReRemember = 0;
        }
        SpinText.rectTransform.DOAnchorPosY( SpinCurrentY + Value, 0.1f)
            .SetEase(Ease.OutBack)
            .OnStepComplete(() => {
                if(Use == false)
                    _spins++;
                Debug.Log(_ticket);
                SpinText.text = $"스핀 횟수 : {_spins.ToString()}"; })
            .OnComplete(() => SpinText.rectTransform.DOAnchorPosY(SpinCurrentY, 0.1f))
            .SetLoops(ReRemember, LoopType.Yoyo);
        SpinText.DOColor(color, 0.1f).SetEase(Ease.OutBack)
            .OnComplete(() => SpinText.DOColor(Color.white, 0.1f))
            .SetLoops(ReRemember, LoopType.Yoyo);;
    }
}
