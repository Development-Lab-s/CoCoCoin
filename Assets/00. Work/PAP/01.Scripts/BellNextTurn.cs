using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _00._Work.PAP._01.Scripts
{
    public class BellNextTurn : MonoBehaviour
    {
        private Vector3 upScale;
        private Vector3 originScale;
        [SerializeField] private Material normalmat;
        [SerializeField] private Material lightmat;
        private SpriteRenderer _sr;

        private void Awake()
        {
            upScale = transform.localScale + Vector3.one * 0.1f;
            originScale = transform.localScale;
            _sr = GetComponent<SpriteRenderer>();
        }

        private void OnMouseDown()
        {
            BattleManager.instance.PassTurn();
        }

        public void OnMouseEnter()
        {
            transform.DOScale(upScale, 0.2f);
        }

        public void Bright()
        {
            _sr.material = lightmat;
        }
        
        public void Normal()
        {
            _sr.material = normalmat;
        }

        public void OnMouseExit()
        {
            transform.DOScale(originScale, 0.2f);
        }
    }
}