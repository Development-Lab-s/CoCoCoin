using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace _00._Work.PAP
{
    public class EnPanel : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        private void Start()
        {
            panel.SetActive(false);
        }

        public void On()
        {
            panel.SetActive(true);
        }
    }
}