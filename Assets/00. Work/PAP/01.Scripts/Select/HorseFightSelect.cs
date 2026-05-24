using System.Text;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "HorseFightSelect", menuName = "SO/Select/HorseFightSelect", order = 0)]
    public class HorseFightSelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventoryItemSO itemLegend;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {
            targetText.SetText($"어느새 결승선 코앞까지 온 빠앙인, 그런데 갑자기..!!\n\'펑-\'\n\"터졌다.\"아니 말이 왜 터지는데..");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            InventoryItemSO item = inventory.inventoryItemList[Random.Range(0, inventory.inventoryItemList.Count)];
            inventory.inventoryItemList.Remove(item);
            targetText.SetText($"달리던 퓌이퓌이가 갑자기!\n멈췄다...\n\"이봐! 자넨 응원을 너무 열심히 했어!\"\n\"퓌이퓌이는 부끄럼을 많이타서 응원을 열심히 하면 멈춰버린다고... \n아무튼 자네 탓이네!\"\n그 남자는 당신의 손에서 <color=#FFFF00>{item.Name} 코인</color>을 낚아채 갔다..</color>");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
            inventory.inventoryItemList.Add(itemLegend);
            targetText.SetText($"\"이럴수가..!\"\n데에브랩이 베르누이의 원리로 가속을 받으며 달립니다!!!\n\"데에브랩 선두! 데에브랩 선두!!!\"\n3... 2... 1.....\n\"고오올!!!! 데에브랩이 1등으로 도착합니다!!!!\"\n당신은 특별한 <color=#FFFF00>{itemLegend.Name} 코인</color>을 얻었다!");
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}