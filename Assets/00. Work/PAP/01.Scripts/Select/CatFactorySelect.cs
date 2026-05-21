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
            targetText.SetText($"기계를 중지 시키려던 순간!\n뒤에서 야옹 소리와 함께 큰 충격을 맞고 기절했다.\n깨어나 보니 당신의 <color=#FF0000>체력이 {decreaseHp} 감소했다..</color>");
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            GameData.instance.playerCurrentHp = Mathf.Min(GameData.instance.playerCurrentHp + 45, 100);
            targetText.SetText($"고양이는...\n놀랍도록 부드러웠다.\n덕분에 당신의 마음도 한결 편해졌다.\n<color=#FFFF00>체력이 45 상승했다.</color>");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
            InventoryItemSO item = chips[Random.Range(0, chips.Length)];
            inventory.inventoryItemList.Add(item);
            targetText.SetText($"수상한 인기척에 주변을 경계했다.\n그러자 구석에 {item.Name}이(가) 보였다.\n당신을 <color=#FFFF00>{item.Name}을(를) 얼른 주어</color> 기괴한 공간을 빠져나갔다...");
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}