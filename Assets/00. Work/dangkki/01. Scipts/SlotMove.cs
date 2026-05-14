using System;
using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine.UI;

public class SlotMove : MonoBehaviour
{
    public Image BlackBack;
    public Button ExitButton;
    public CinemachineCamera Camera;
    private void Awake()
    {
        DOTween.Init();
        Sequence seq = DOTween.Sequence();
        seq.Append(BlackBack.DOFade(0, 0.5f));
        seq.Append(transform.DOMoveY(0, 0.0f)/*.SetEase(Ease.OutBack , 0.5f,3)*/.OnComplete((() =>
        {
            gameObject.SetActive(true);
            ExitButton.gameObject.SetActive(true);
            BlackBack.gameObject.SetActive(false);
        })));;
        seq.Play();
    }

    public void Show()
    {
        if (!BlackBack.gameObject.active) BlackBack.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        //seq.Append(BlackBack.DOFade(0, 0.5f));
        seq.Append(BlackBack.DOFade(1, 0.5f));
        seq.Append(Camera.transform.DOMoveX(-30, 0.0f)/*.SetEase(Ease.OutBack , 0.5f,3)*/.OnComplete((() =>
        {
            //Shop.gameObject.SetActive(true);
            //ExitButton.gameObject.SetActive(true);
        })));;
        seq.Append(BlackBack.DOFade(1, 0.2f));
        seq.Append(BlackBack.DOFade(0, 0.5f).OnComplete(() => BlackBack.gameObject.SetActive(false)));
        seq.Play();
    }

    public void Hide()
    {
        if (!BlackBack.gameObject.active) BlackBack.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        seq.Append(BlackBack.DOFade(1, 0.5f));
        seq.Append(Camera.transform.DOMoveX(0, 0.2f)/*.SetEase(Ease.InBack, 0.3f , 2)*/.OnComplete((() =>
        {
            //ExitButton.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            
            
        })));
        seq.Append(BlackBack.DOFade(1, 0.2f));
        seq.Append(BlackBack.DOFade(0, 0f).OnComplete(() => BlackBack.gameObject.SetActive(false)));
        seq.Play();
    }
}
