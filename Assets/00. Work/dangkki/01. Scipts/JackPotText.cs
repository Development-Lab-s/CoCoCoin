using System;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class JackPotText : MonoBehaviour
{
    TextMeshProUGUI jackpotText;
    private void Awake()
    {
        jackpotText =  GetComponent<TextMeshProUGUI>();
        DOTween.Init();
        jackpotText.DOFade(0, 0);
    }

    public void ShowText()
    {
        
        Sequence s = DOTween.Sequence();
        s.Append(jackpotText.DOFade(1, 0.2f));
        
        s.Append(jackpotText.DOColor(Color.red, 0.1f)); 
        s.Append(jackpotText.DOColor(Color.white, 0.1f));
        s.Append(jackpotText.DOColor(Color.magenta, 0.1f));
        s.Append(jackpotText.DOColor(Color.blue, 0.1f));
        s.Append(jackpotText.DOColor(Color.yellow, 0.1f));
            
        s.Play().SetLoops(2).OnComplete((() => jackpotText.DOFade(0, 0.2f) ));
    }
}
