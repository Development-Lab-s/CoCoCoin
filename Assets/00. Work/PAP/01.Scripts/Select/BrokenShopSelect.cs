using System.Text;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "BrokenShopSelect", menuName = "SO/Select/BrokenShopSelect", order = 0)]
    public class BrokenShopSelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {
            InventoryItemSO item = inventory.inventoryItemList[Random.Range(0, inventory.inventoryItemList.Count)];
            inventory.inventoryItemList.Remove(item);
            targetText.SetText($"그 곳엔.. 농땡이 치며 디코나 하는 상점 책임자가 있었다. \n\"말도 안 돼! 사람이라면, 양심이 있다면 저럴 순 없잖아!!\"\n당신은 충격에 헐레벌떡 뛰쳐나오다, <color=#FFFF00>{item.Name} 코인</color>을 하나 떨어트렸다..</color>");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            InventoryItemSO item = chips[Random.Range(0, chips.Length)];
            inventory.inventoryItemList.Add(item);
            targetText.SetText($"책임자를 믿고 상점을 지나쳤다.\n지나치던 도중, 누군가가 상점으로 들어간 것이 보였다.\n상점 안이 굉장히 시끄러워졌다.\n그것에 대한 여파였나, 공사중인 상점에서 <color=#FFFF00>{item.Name} 코인</color>이 튕겨 나왔다.</color>");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}