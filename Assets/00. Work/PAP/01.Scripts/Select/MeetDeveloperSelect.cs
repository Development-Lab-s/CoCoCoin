using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "MeetDeveloperSelect", menuName = "SO/Select/MeetDeveloperSelect", order = 0)]
    public class MeetDeveloperSelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {
            InventoryItemSO item = chips[Random.Range(0, chips.Length)];
            inventory.inventoryItemList.Add(item);
            targetText.SetText($"\"그래!! 난 개발이였어!!!\"\n<color=#FFFF00>{item.Name}을(를) 하나 얻었다!</color>");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            InventoryItemSO item = inventory.inventoryItemList[Random.Range(0, inventory.inventoryItemList.Count)];
            targetText.SetText($"갑자기 눈 앞이 어두워졌고, 정신을 차리자 그 남자는 사라지고 없었다.\n<color=#FF0000>{item.Name}이(가) 하나 사라졌다..</color>");
            inventory.inventoryItemList.Remove(item);
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}