using System;
using DG.Tweening;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Motions
{
    public class DrawMotionHandler : MonoBehaviour
    {
        [SerializeField] private GameObject DrawHand;
        [SerializeField] private CanvasGroup DrawChips;
        [SerializeField] private Animator drawHandAnimator;
        private Vector3 originPos;
        private Vector3 firstPos = new Vector3(-8.5f, -4.5f, 0);
        private Vector3 secondPos = new Vector3(-8f, -5.2f, 0);
        private Vector3 thirdPos = new Vector3(-7.5f, -10f, 0);
        private bool DrawHandActive = true;

        private void Start()
        {
            originPos = DrawHand.transform.position;
        }

        public void DrawChipMotion()
        {
            if (!DrawHandActive)
                return;
            DrawHandActive = false;
            DrawHand.transform.position = originPos;
            Sequence _seq = DOTween.Sequence();
            _seq.Append(DrawHand.transform.DOMove(firstPos, 0.3f));
            _seq.AppendCallback(() =>
            {
                drawHandAnimator.SetBool("Draw", true);
                DrawChips.alpha = 0;
            });
            _seq.Append(DrawHand.transform.DOMove(secondPos, 0.3f));
            _seq.AppendInterval(0.4f);
            _seq.AppendCallback(() => { DrawChips.alpha = 1; });
            _seq.Append(DrawHand.transform.DOMove(thirdPos, 0.5f));
            _seq.AppendCallback(() =>
            {
                drawHandAnimator.SetBool("Draw", false);
                DrawHandActive = true;
                BattleManager.instance.currentState = BattleManager.State.PlayerTurn;
            });
        }
    }
}