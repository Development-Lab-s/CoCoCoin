using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts
{
    public abstract class ChoiceSelect : ScriptableObject
    {
        
        public abstract void Select1(TextMeshProUGUI targetText);
        public abstract void Select2(TextMeshProUGUI targetText);
        public abstract void Select3(TextMeshProUGUI targetText);
        public abstract void Select4(TextMeshProUGUI targetText);
    }
}