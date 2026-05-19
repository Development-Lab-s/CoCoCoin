using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Video;

public class ShopPopup : MonoBehaviour
{
    public Button button;
    public Image BlackBack;
    public GameObject Shop;
    public Button ExitButton;
    public VideoPlayer VideoPlayer;
    public RawImage Background;
    public Texture2D backgroundImage;
    public RenderTexture BackAnim;
    public VideoClip[] Vid;
    public Button slotButton;
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
        VideoPlayer.clip = Vid[0];
        Background.texture = BackAnim;
        VideoPlayer.Play();
        BlackBack.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        //seq.Append(transform.DOScale(1.1f, 0.1f));
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
        seq.Append(BlackBack.DOFade(0, 1f));
        //seq.Append(transform.DOScale(0, 0.1f));
        seq.Play();
        StartCoroutine(Delay(false));
        
    }

    public void Hide()
    {
        VideoPlayer.clip = Vid[1];
        VideoPlayer.Play();
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
            
        })));
        seq.Append(BlackBack.DOFade(1, 0.2f));
        //VideoPlayer.clip = Vid[1];
       // VideoPlayer.Play();
        seq.Append(BlackBack.DOFade(0, 1f).OnComplete(() => BlackBack.gameObject.SetActive(false)));
        StartCoroutine(Delay(true));
        //seq.Play().OnComplete(() => gameObject.SetActive(false));
        Background.texture = backgroundImage;
    }

    public IEnumerator Delay(bool flag)
    {
        button.enabled = false;
        yield return new WaitForSecondsRealtime(1f);
        button.enabled = true;
        BlackBack.gameObject.SetActive(flag);
    }
}
