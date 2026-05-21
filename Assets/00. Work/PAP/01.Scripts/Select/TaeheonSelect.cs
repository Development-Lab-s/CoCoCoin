using System.Text;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "TaeheonSelect", menuName = "SO/Select/TaeheonSelect", order = 0)]
    public class TaeheonSelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventoryItemSO itemLegend;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                InventoryItemSO item = chips[Random.Range(0, chips.Length)];
                inventory.inventoryItemList.Add(item);
                stringBuilder.Append($"{item.Name}, ");
            } 
            inventory.inventoryItemList.Add(itemLegend);
            targetText.SetText($"[좋아, 이건 널 위한거야]\n그가 사라졌다..\n<color=#FFFF00>{stringBuilder}들을 얻었다!</color>\n...<color=#FFFF00>특별한 {itemLegend.Name}을(를) 얻었다..!</color>");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}