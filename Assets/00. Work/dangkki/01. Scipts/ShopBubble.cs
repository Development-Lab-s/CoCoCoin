using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

public class ShopBubble : MonoBehaviour
{
    
    [Multiline(3)]
    public String[] BubbleText;
    public TextMeshProUGUI Bubble;
    public Button Waiter;

    private void Awake()
    {
        DOTween.Init();
        Bubble.text = null;
    }
    
    public void Play()
    {
        Bubble.text = null;
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        Waiter.interactable = false;
        foreach (char _text in BubbleText[Random.RandomRange(0, BubbleText.Length)])
        {
            Bubble.text += _text;
            yield return new WaitForSeconds(0.08f);
        }
        Waiter.interactable = true;
        
        
        /*for (int i = 0; i < BubbleText.Length; i++)
        {
        
            for (int x = 0; i < BubbleText[x].Length; i++)
            {
                Bubble.text += BubbleText[i][x];
                
            }
        }*/
    }
}
