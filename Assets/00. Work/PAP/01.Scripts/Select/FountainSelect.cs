using System.Text;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "FountainSelect", menuName = "SO/Select/FountainSelect", order = 0)]
    public class FountainSelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {
            InventoryItemSO item1 = inventory.inventoryItemList[Random.Range(0, inventory.inventoryItemList.Count)];
            inventory.inventoryItemList.Remove(item1);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                InventoryItemSO item = chips[Random.Range(0, chips.Length)];
                inventory.inventoryItemList.Add(item);
                stringBuilder.Append(i == 1 ? item.Name : $"{item.Name}, ");
            } 
            targetText.SetText($"<color=#FF0000>{item1.Name}을 던지고</color> 한동안 아무 일도 없었다\n돈을 버렸구나 생각하며 나서자 밑에 무언가 밟힌다\n정말 행운을 가져다주었다.\n<color=#FFFF00>{stringBuilder}들을 가져갈수 있었다.</color>");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            targetText.SetText($"당신은 저런 미신을 믿지 않는 사람이다.\n아무일도 일어나지 않았다");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}