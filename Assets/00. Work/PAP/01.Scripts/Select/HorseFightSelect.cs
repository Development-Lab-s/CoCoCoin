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
            InventoryItemSO item = inventory.inventoryItemList[Random.Range(0, inventory.inventoryItemList.Count)];
            inventory.inventoryItemList.Remove(item);
            targetText.SetText($"달리던 빠앙인이 갑자기!\n달리다 멈췄다...\n\"이봐 자네! 응원을 너무 열심히 한거 아닌가?\"\n\"빠앙인은 부끄럼을 많이타서 응원을 열심히 하면 멈춰버린다고...\"\n\"아무튼 자네 탓이네!!\"\n그러자 남자가 <color=#FF0000>{item.Name}을(를)뺏어가 버렸다..</color>");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            targetText.SetText($"\"빠앙인을 뒤따라 달리는 퓌이피이..!!!\"\n\"에에? 퓌이피이가 달리다 넘어졌..습니다?\"\n결과를 본 당신은 깊게 실망한다.\n그래도 경마는 재미있었다.\n아무일도 없었다.");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
            inventory.inventoryItemList.Add(itemLegend);
            targetText.SetText($"\"으아악 말도 안되는 장면!\"\n데에브랩이 베르누이의 원리로 가속을 받으며 달립니다!!!\n\"데에브랩 선두! 데에브랩 선두!!!\"\n그러자 3... 2... 1.....\n\"고오올!!!! 데에브랩이 1등으로 도착합니다!!!!\"\n...<color=#FFFF00>특별한 {itemLegend.Name}을(를) 얻었다..!</color>");
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}