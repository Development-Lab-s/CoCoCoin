using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _00._Work.PAP._01.Scripts
{
    public class UIHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] private RawImage targetImage;
        [SerializeField] private Material materialChange;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            targetImage.material = materialChange;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            targetImage.material = null;
        }

        private void OnDisable()
        {
            if (targetImage)
            {
                targetImage.material = null;
            }
        }
    }
}