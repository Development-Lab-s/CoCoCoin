using System;
using UnityEngine;
using DG.Tweening;

public class ObjEffect : MonoBehaviour
{
    public float scaleX;
    public float scaleY;
    private void Awake()
    {
        DOTween.Init();
    }

    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        //seq.Append(transform.DOScale(new Vector3(scaleX, scaleY, 0), 1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo));
    }
}
