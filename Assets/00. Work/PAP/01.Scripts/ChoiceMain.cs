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
        [SerializeField] private GameObject ExitButton;
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
            CallChoice(0);
        }
        public void Button2()
        {
            CallChoice(1);

        }
        public void Button3()
        {
            CallChoice(2);

        }
        public void Button4()
        {
            CallChoice(3);
        }

        private void CallChoice(int index)
        {
            if (enable)
            {
                enable = false;
                switch (index) 
                {
                    case 0 :
                        choiceData.choiceData.selects.Select1(choiceText);
                        break;
                    case 1 :
                        choiceData.choiceData.selects.Select2(choiceText);
                        break;
                    case 2 :
                        choiceData.choiceData.selects.Select3(choiceText);
                        break;
                    case 3 :
                        choiceData.choiceData.selects.Select4(choiceText);
                        break;
                }
                for (int i = 0; i < choiceData.choiceData.choiceButtons.Length; i++)
                {
                    choiceButtons[i].SetActive(false);
                }
                ExitButton.SetActive(true);
            }
        }

        public void Exit()
        {
            _ = SceneManageHandler.instance.MoveScene(1);
        }
    }
}