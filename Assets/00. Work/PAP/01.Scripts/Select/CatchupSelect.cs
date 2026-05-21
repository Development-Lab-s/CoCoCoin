using System.Text;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    [CreateAssetMenu(fileName = "CahtchupSelect", menuName = "SO/Select/CahtchupSelect", order = 0)]
    public class CahtchupSelect : ChoiceSelect
    {
        public override void Select1(TextMeshProUGUI targetText)
        {
            int decreaseHp = (int)(GameData.instance.playerCurrentHp * 0.1f);
            GameData.instance.playerCurrentHp -= decreaseHp;
            targetText.SetText($"케찹이라... 재미있는 소리네?\n내가 원한건 'Catchup'이라고.\n<color=#FFFF00>피해를 {decreaseHp}</color> 입었다.");

        }

        public override void Select2(TextMeshProUGUI targetText)
        {
            int decreaseHp = (int)(GameData.instance.playerCurrentHp * 0.1f);
            GameData.instance.playerCurrentHp -= decreaseHp;
            targetText.SetText($"캐챂이라... 완전 '골' 때리는 소리네?\n내가 원한건 'Catchup'이라고..\n<color=#FFFF00>피해를 {decreaseHp}</color> 입었다.");
        }

        public override void Select3(TextMeshProUGUI targetText)
        {
            GameData.instance.playerCurrentHp = 100;
            targetText.SetText($"켓찹이라... 완전 내가 원하던거야.\n그래 선물을 줄게 자, 여기\n해골이 골골되며 떠나간다.\n<color=#33FF00>체력을 완전히 회복</color> 했다.");
        }

        public override void Select4(TextMeshProUGUI targetText)
        {
            int decreaseHp = (int)(GameData.instance.playerCurrentHp * 0.2f);
            GameData.instance.playerCurrentHp -= decreaseHp;
            targetText.SetText($"더러운 고양이 학살자.\n<color=#FFFF00>피해를 {decreaseHp}</color> 입었다.");
        }
    }
}