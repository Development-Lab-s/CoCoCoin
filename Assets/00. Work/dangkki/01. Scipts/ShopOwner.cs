using System;
using UnityEngine;
using DG.Tweening;

public class ShopOwner : MonoBehaviour
{
    private ShopBubble bubble;
    private void Awake()
    {
        bubble = GetComponentInChildren<ShopBubble>();
        DOTween.Init();
    }

    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveY(-50f, 1f).SetEase(Ease.OutBack, 0.5f, 1).OnComplete(() =>
        {
            bubble.Play("안녕하세요!");
        }).SetDelay(0.3f));
        seq.Play();
    }
}
