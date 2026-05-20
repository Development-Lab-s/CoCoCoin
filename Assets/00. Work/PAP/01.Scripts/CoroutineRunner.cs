using System;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts
{
    public class CoroutineRunner : MonoBehaviour
    {
        public static CoroutineRunner instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
    }
}