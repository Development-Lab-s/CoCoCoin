using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using Sequence = DG.Tweening.Sequence;

public class CamMove : MonoBehaviour
{
    private bool enabled = true;
    void Start()
    {
        DOTween.Init();
    }
    

    public void LeftHover()
    {
        if (!enabled) return;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveX(-0.5f, 0.5f));
        
    }
    

    public void LeftHoverEnd()
    {
        if (!enabled) return;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveX(0.5f, 0.5f));
    }

    public void LeftClick()
    {
        if (!enabled) return;
        enabled = !enabled;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveX(-10f, 0.5f).SetEase(Ease.OutBack, 0.2f, 1));
    }
    
    public void RightHover()
    {
        if (enabled) return;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveX(-9.5f, 0.5f));
        
    }
    

    public void RightHoverEnd()
    {
        if (enabled) return;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveX(-10f, 0.5f));
    }

    public void RightClick()
    {
        if (enabled) return;
        enabled = true;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveX(0f, 0.5f).SetEase(Ease.OutBack, 0.2f, 1));
    }
}
