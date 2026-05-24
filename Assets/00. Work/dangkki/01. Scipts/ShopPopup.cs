using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.Video;
using Sequence = DG.Tweening.Sequence;

public class ShopPopup : MonoBehaviour
{
    public Button button;
    public Image BlackBack;
    public GameObject Shop;
    public Button ExitButton;
    public Button slotButton;
    public WalkCam walkCam;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        DOTween.Init();
        //transform.localScale = Vector3.one * 0.1f;
        Shop.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        
        Sequence seq = DOTween.Sequence();
        seq.Append(BlackBack.DOFade(0, 0.5f));
            seq.Play().OnComplete(() =>
            {
                BlackBack.gameObject.SetActive(false);
                
            });
    }
    public void Show()
    {
        BlackBack.gameObject.SetActive(true);
        audioSource.Play();
        
        walkCam.moveDistance = 100;
        walkCam.moveDuration = 1f;
        walkCam.target = transform.parent.GetChild(0).transform;
        walkCam.Play(true);
        
        
        Sequence seq = DOTween.Sequence();
        seq.SetAutoKill(false);
        //seq.OnRewind(() => BlackBack.enabled = true);
        seq.Append(BlackBack.DOFade(0, 0.5f));
        seq.Append(BlackBack.DOFade(1, 0.5f));
        seq.Append(Shop.transform.DOMoveY(0, 0.0f)/*.SetEase(Ease.OutBack , 0.5f,3)*/.OnComplete((() =>
        {
            Shop.gameObject.SetActive(true);
            ExitButton.gameObject.SetActive(true);
            slotButton.gameObject.SetActive(false);
        })));;
        seq.Append(BlackBack.DOFade(1, 0.2f));
        seq.Append(BlackBack.DOFade(0, 1f).OnComplete(() => BlackBack.gameObject.SetActive(false)));
        //seq.Append(transform.DOScale(0, 0.1f));
        seq.Play();
        StartCoroutine(Delay(true));
        
    }

    public void Hide()
    {
        BlackBack.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        //transform.localScale = Vector3.one * 0.2f;
        //seq.Append(transform.DOScale(1.1f, 0.05f));
        //seq.Append(transform.DOScale(0.1f, 0.1f));
        seq.SetAutoKill(false);
       // seq.OnRewind(() => BlackBack.enabled = true);
        seq.Append(BlackBack.DOFade(1, 0.5f));
        seq.Append(Shop.transform.DOMoveY(0, 0.2f)/*.SetEase(Ease.InBack, 0.3f , 2)*/.OnComplete((() =>
        {
            Shop.gameObject.SetActive(false);
            ExitButton.gameObject.SetActive(false);
            slotButton.gameObject.SetActive(true);
            
            walkCam.target = null;
            walkCam.moveDistance = 08;
            walkCam.moveDuration = 0.9f;
            walkCam.Play(false);
            
        })));
        seq.Append(BlackBack.DOFade(1, 0.2f));
        seq.Append(BlackBack.DOFade(0, 1f).OnComplete(() => BlackBack.gameObject.SetActive(false)));
        StartCoroutine(Delay(true));
        //seq.Play().OnComplete(() => gameObject.SetActive(false));
    }

    public IEnumerator Delay(bool flag)
    {
        button.enabled = false;
        yield return new WaitForSecondsRealtime(1f);
        button.enabled = true;
        BlackBack.gameObject.SetActive(flag);
    }
}
