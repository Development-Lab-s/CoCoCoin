using System;
using DG.Tweening;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Motions
{
    public class TurnHandMotionHandler : MonoBehaviour
    {
        [SerializeField] private GameObject targetHandObject;
        private Vector3 targetHandPosition;

        private void Start()
        {
            targetHandPosition = targetHandObject.transform.position;
        }

        public void PlayMotion()
        {
            Sequence _seq = DOTween.Sequence();
            _seq.Append(targetHandObject.transform.DOMove(new Vector3(-3.78f, -3.44f, 0), 0.5f));
            _seq.Append(targetHandObject.transform.DOMove(new Vector3(-3.78f, -3.7f, 0), 0.1f));
            _seq.Append(targetHandObject.transform.DOMove(new Vector3(-3.78f, -3.44f, 0), 0.1f));
            _seq.Append(targetHandObject.transform.DOMove(targetHandPosition, 0.3f));
        }
    }
}