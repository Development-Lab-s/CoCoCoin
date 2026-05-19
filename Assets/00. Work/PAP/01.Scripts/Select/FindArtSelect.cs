using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "FindArtSelect", menuName = "SO/Select/FindArtSelect", order = 0)]
    public class FindArtSelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {

            targetText.SetText($"그 남자는 당신에게 감사 인사를 한 뒤, 주머니에서 채찍을 꺼내 화장실로 향했다...");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            InventoryItemSO item = chips[Random.Range(0, chips.Length)];
            inventory.inventoryItemList.Add(item);
            targetText.SetText($"그 남자에게 답례로 <color=#FFFF00>{item.Name}을(를) 받았다!</color>\n그 후 당신이 말한 방향으로 뛰어갔다..");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}