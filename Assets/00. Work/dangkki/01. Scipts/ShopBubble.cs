using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ShopBubble : MonoBehaviour
{
    
    [Multiline(3)]
    public String[] BubbleText;
    public TextMeshProUGUI Bubble;

    private void Awake()
    {
        Bubble.text = null;
    }
    
    public void Play()
    {
        Bubble.text = null;
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        foreach (char _text in BubbleText[1])
        {
            Bubble.text += _text;
            yield return new WaitForSeconds(0.08f);
        }
        
        /*for (int i = 0; i < BubbleText.Length; i++)
        {
        
            for (int x = 0; i < BubbleText[x].Length; i++)
            {
                Bubble.text += BubbleText[i][x];
                
            }
        }*/
    }
}
