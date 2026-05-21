using System.Text;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "ArtHeroSelect", menuName = "SO/Select/ArtHeroSelect", order = 0)]
    public class ArtHeroSelect : ChoiceSelect
    {
        [SerializeField] private InventoryItemSO[] chips;
        [SerializeField] private InventorySO inventory;
        public override void Select1(TextMeshProUGUI targetText)
        {
            targetText.SetText($"아트 용사는 곧바로 당신을 베어내었다!\n<color=#FF0000>피해를 50</color> 입었다.\n당신은 쫓아오는 아트 용사를 피해 도망친다..");
            GameData.instance.playerCurrentHp /= 2;
        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                InventoryItemSO item = chips[Random.Range(0, chips.Length)];
                inventory.inventoryItemList.Add(item);
                stringBuilder.Append($"{item.Name}, ");
            } 
            targetText.SetText($"\"음, 그래야지~\"\n아ㅌ 아니 개발 용사는 만족한듯 미소짓는다.\n\"맞아 난 개발 용사야!\"\n<color=#FFFF00>{stringBuilder} 코인</color>을 받았다!");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
        }
    }
}