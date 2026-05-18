using System;
using UnityEngine;
using DG.Tweening;

public class ObjEffect : MonoBehaviour
{
    private void Awake()
    {
        DOTween.Init();
    }

    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(DOTween.To()));
    }
}
