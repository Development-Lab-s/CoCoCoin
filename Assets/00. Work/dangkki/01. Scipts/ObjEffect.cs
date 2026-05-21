using System;
using UnityEngine;
using DG.Tweening;

public class ObjEffect : MonoBehaviour
{
    [SerializeField] private Material material;
    private void Awake()
    {
        DOTween.Init();
    }

    private void Start()
    {
    }
    
}
