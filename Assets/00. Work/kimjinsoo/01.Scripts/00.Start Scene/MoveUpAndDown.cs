using DG.Tweening;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{

    RectTransform rectTrans;
    Vector2 originPos;

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        originPos = rectTrans.anchoredPosition;
        rectTrans.DOAnchorPosY(originPos.y + 20, 2f).SetLoops(-1, LoopType.Yoyo);//.SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        rectTrans.DOKill();
    }
}
