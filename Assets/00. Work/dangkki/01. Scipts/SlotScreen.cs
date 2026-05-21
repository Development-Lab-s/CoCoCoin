using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Cinemachine;

public class SlotScreen : MonoBehaviour
{
    public Image Background;
    public CinemachineCamera Camera;
    

    private void Awake()
    {
        DOTween.Init();
    }

    public void Shake()
    {
        Camera.transform.DOLocalMoveY(0.5f, 0.1f).SetEase(Ease.InBack)
            .OnComplete(() => Camera.transform.DOLocalMoveY(0, 0.1f));;
    }
}
