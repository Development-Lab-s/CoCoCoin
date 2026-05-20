using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = System.Random;

namespace _00._Work.PAP._01.Scripts
{
    public class EnemyThemeSetting : MonoBehaviour
    {
        [SerializeField] private CurrentEnemySetting enemySetting;
        [SerializeField] private AudioSource theme;
        [SerializeField] private AudioResource[] randomTheme;

        private void Start()
        {
            if (enemySetting.Data.Theme)
            {
                theme.resource = enemySetting.Data.Theme;
            }
            else
            {
                theme.resource = randomTheme[UnityEngine.Random.Range(0, randomTheme.Length)];
            }
            theme.Play();
        }
    }
}