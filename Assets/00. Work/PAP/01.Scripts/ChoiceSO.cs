using UnityEngine;

namespace _00._Work.PAP._01.Scripts
{
    [CreateAssetMenu(fileName = "Choice data", menuName = "SO/Choice data", order = 0)]
    public class ChoiceSO : ScriptableObject
    {
        [TextArea(10,50)] public string choiceText;
        public Sprite choiceImage;
        public string[] choiceButtons;
    }
}