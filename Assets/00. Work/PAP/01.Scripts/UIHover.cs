using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _00._Work.PAP._01.Scripts
{
    public enum Tool
    {
        Machine,
        Shop,
        Exit,
    }
    public class UIHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] private RawImage targetImage;
        [SerializeField] private Material materialChange;
        [SerializeField] private ShopBubble shopBubble;
        [SerializeField] private Tool tool;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (tool == Tool.Machine)
            {
                shopBubble.Play("슬롯 머신! 티켓을 뽑기 좋은 수단이죠.");
            }
            else if (tool == Tool.Shop)
            {
                shopBubble.Play("저희는 최상급만 공수합니다. 그 전에, 슬롯머신에서 티켓은 뽑아 오셨겠죠?");
            }
            else if (tool == Tool.Exit)
            {
                shopBubble.Play("잠깐! 나가시려고요? 소상공인도 먹고 살아야죠!");
            }
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