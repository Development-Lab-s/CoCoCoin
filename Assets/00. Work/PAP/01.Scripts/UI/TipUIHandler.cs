using DG.Tweening;
using UnityEngine;

public class TipUIHandler : MonoBehaviour
{
    [SerializeField] CanvasGroup trashTip;

    public void ShowTrashTip()
    {
        trashTip.DOFade(0.9f, 1f);
    }

    public void HideTrashTip()
    {
        trashTip.DOFade(0f, 1f);
    }
}
