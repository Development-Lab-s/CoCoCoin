using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EffectFingerSnap : MonoBehaviour
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
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        seq.Append(image.DOFade(1f, 0.3f));
        seq.AppendInterval(0.2f);
        seq.Append(image.DOFade(0f, 0.3f));
        seq.AppendCallback(()=>Destroy(killthem));
    }
}
