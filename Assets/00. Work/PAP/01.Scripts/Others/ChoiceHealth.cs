using System;
using TMPro;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Select
{
    public class ChoiceHealth : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthTextUI;



        private void Update()
        {
            healthTextUI.SetText(GameData.instance.playerCurrentHp.ToString());
        }
    }
}