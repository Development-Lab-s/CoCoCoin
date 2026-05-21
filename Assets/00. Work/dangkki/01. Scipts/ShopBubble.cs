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
    public TextMeshProUGUI Bubble;
    public Button Waiter;
    public Coroutine bubbleCoroutine;

    private void Awake()
    {
        DOTween.Init();
        Bubble.text = null;
    }
    
    public void Play(string content)
    {
        Bubble.text = null;
        if (bubbleCoroutine != null)
        {
            StopCoroutine(bubbleCoroutine);
            bubbleCoroutine = null;
        }
        bubbleCoroutine = StartCoroutine(Delay(content));
    }

    public IEnumerator Delay(string content)
    {
        
        Waiter.interactable = false;
        foreach (char _text in content)
        {
            Bubble.text += _text;
            yield return new WaitForSeconds(0.03f);
        }
        Waiter.interactable = true;
    }
}
