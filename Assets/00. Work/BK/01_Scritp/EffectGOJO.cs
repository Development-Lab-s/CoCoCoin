using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EffectGOJO : MonoBehaviour
{
    private Image image;
    [SerializeField] private GameObject killthem;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        Sequence seq =  DOTween.Sequence();
        
        seq.Append(image.DOFade(1f, 0.5f));
        seq.AppendInterval(1f);
        seq.Append(image.DOFade(0f, 0.5f));
        seq.AppendCallback(()=>Destroy(killthem));
    }
}
