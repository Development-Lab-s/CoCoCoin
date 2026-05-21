using System.Text;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "CoCoCoinSelect", menuName = "SO/Select/CoCoCoinSelect", order = 0)]
    public class CoCoCoinSelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                InventoryItemSO item = chips[Random.Range(0, chips.Length)];
                inventory.inventoryItemList.Add(item);
                stringBuilder.Append(i == 4 ? item.Name : $"{item.Name}, ");
            } 
            targetText.SetText($"감사합니다! 별점 5점 남겨주세요\n리뷰는 겜마고 포트폴리오 사이트에서~\n{stringBuilder} 획득~~!!");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            targetText.SetText($"저희 '코코코인' 카지노는 [아트] 능력이 뛰어난 분을 찾습니다!\n당신은 '코코코인'을 향해 뛰어돌아갔다..");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}