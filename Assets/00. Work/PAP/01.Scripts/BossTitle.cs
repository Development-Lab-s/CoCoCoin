using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts
{
    public class BossTitle : MonoBehaviour
    {
        [SerializeField] private CurrentEnemySetting currentEnemy;
        [SerializeField] private TextMeshProUGUI titleText;

        private void Start()
        {
            if (currentEnemy.Data.Title != "")
            {
                titleText.SetText(currentEnemy.Data.Title);
                titleText.transform.localScale = Vector3.zero;
                Sequence _seq = DOTween.Sequence();
                _seq.Append(titleText.transform.DOScale(Vector3.one, 0.5f));
                _seq.AppendInterval(1f);
                _seq.Append(titleText.DOFade(0f, 0.5f));
            }
        }
    }
}