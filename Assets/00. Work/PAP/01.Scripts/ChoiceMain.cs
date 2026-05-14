using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _00._Work.PAP._01.Scripts
{
    public class ChoiceMain : MonoBehaviour
    {
        [SerializeField] private Image choiceImage;
        [SerializeField] private TextMeshProUGUI choiceText;
        [SerializeField] private CurrentChoiceData choiceData;
        [SerializeField] private GameObject[] choiceButtons;
        [SerializeField] private ChoiceSelect[] selectChoice;
        private bool enable = true;
        

        public void Start()
        {
            choiceImage.sprite = choiceData.choiceData.choiceImage;
            choiceText.SetText(choiceData.choiceData.choiceText);
            for (int i = 0; i < choiceData.choiceData.choiceButtons.Length; i++)
            {
                choiceButtons[i].SetActive(true);
                choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().SetText(choiceData.choiceData.choiceButtons[i]);
            }
        }

        public void Button1()
        {
            if (enable)
            {
                enable = false;
                selectChoice[0].Select();
            }
        }
        public void Button2()
        {
            if (enable)
            {
                enable = false;
                selectChoice[1].Select();
            }
        }
        public void Button3()
        {
            if (enable)
            {
                enable = false;
                selectChoice[2].Select();
            }
        }
        public void Button4()
        {
            if (enable)
            {
                enable = false;
                selectChoice[3].Select();
            }
        }
    }
}