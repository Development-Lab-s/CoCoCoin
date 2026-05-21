using System;
using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;

public class SlotMove : MonoBehaviour
{
    public Image BlackBack;
    public Button ExitButton;
    public CinemachineCamera Camera;
    public WalkCam WalkCam;
    public Transform SlotEnter;
    [SerializeField] private GameObject disableObject;
    [SerializeField] private AudioSource audioSource;
    private void Awake()
    {
        WalkCam = Camera.gameObject.GetComponent<WalkCam>();
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
        WalkCam.target = SlotEnter.transform;
        WalkCam.moveDistance = 100;
        WalkCam.moveDuration = 1f;
        audioSource.Play();
        WalkCam.Play(true);
        SlotEnter.gameObject.SetActive(false);
        disableObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        if (!BlackBack.gameObject.active) BlackBack.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        //seq.Append(BlackBack.DOFade(0, 0.5f));
        seq.Append(BlackBack.DOFade(1, 0.7f));
        seq.Append(transform.DOMoveX(0, 0.3f)/*.SetEase(Ease.OutBack , 0.5f,3)*/.OnComplete((() =>
        {
        })));;
        seq.Append(BlackBack.DOFade(1, 0.2f));
        seq.Append(BlackBack.DOFade(0, 0.5f).OnComplete(() =>
        {
            BlackBack.gameObject.SetActive(false);
        }));
        seq.Play();
    }

    public void Hide()
    {
        if (!BlackBack.gameObject.active) BlackBack.gameObject.SetActive(true);
        disableObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        ExitButton.gameObject.SetActive(true);
        seq.Append(BlackBack.DOFade(1, 0.5f));
        seq.Append(transform.DOMoveX(-30, 0.3f)/*.SetEase(Ease.InBack, 0.3f , 2)*/.OnComplete((() =>
        {
            //ExitButton.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            WalkCam.target = null;
            WalkCam.moveDistance = 80;
            WalkCam.moveDuration = 0.9f;
            WalkCam.Play(false);
            
        })));
        seq.Append(BlackBack.DOFade(1, 0.2f));
        seq.Append(BlackBack.DOFade(0, 0.5f).OnComplete(() =>
        {
            BlackBack.gameObject.SetActive(false);
        }));
        seq.Play();
        SlotEnter.gameObject.SetActive(true);
    }
}
