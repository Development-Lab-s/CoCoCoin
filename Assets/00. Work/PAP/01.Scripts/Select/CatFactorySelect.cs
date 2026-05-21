using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "CatFactorySelect", menuName = "SO/Select/CatFactorySelect", order = 0)]
    public class CatFactorySelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {
            int decreaseHp = GameData.instance.playerCurrentHp / 4;
            GameData.instance.playerCurrentHp -= decreaseHp;
            targetText.SetText($"작동 중지 버튼을 누르려던 순간,\n뒤에서 '야옹' 소리와 함께 머리를 맞고 기절했다.\n<color=#FF0000>피해를 {decreaseHp}</color> 입었다..");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            GameData.instance.playerCurrentHp = Mathf.Min(GameData.instance.playerCurrentHp + 45, 100);
            targetText.SetText($"고양이는...\n놀랍도록 부드러웠다!\n덕분에 당신의 마음도 한결 편해진다.\n<color=#33FF00>체력을 45 회복</color> 했다.");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
            InventoryItemSO item = chips[Random.Range(0, chips.Length)];
            inventory.inventoryItemList.Add(item);
            targetText.SetText($"수상한 인기척에 주변을 경계했다.\n다른 누군가를 찾진 못했으나, 바닥에서 <color=#FFFF00>{item.Name} 코인</color>을 발견했다.\n당신은 얼른 <color=#FFFF00>{item.Name} 코인</color>을 챙겨 그 공간을 빠져나왔다...");
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}