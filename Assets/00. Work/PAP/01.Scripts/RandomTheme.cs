using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace _00._Work.PAP._01.Scripts
{
    public class RandomTheme : MonoBehaviour
    {
        [SerializeField] private AudioResource[] randomTheme;
        [SerializeField] private AudioSource audioSource;
        private void Start()
        {
            audioSource.resource = randomTheme[Random.Range(0, randomTheme.Length)];
            audioSource.Play();
        }
    }
}