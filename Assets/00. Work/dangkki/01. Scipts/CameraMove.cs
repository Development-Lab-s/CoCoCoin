using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]private CinemachineCamera[] cameras;
    private CinemachineCamera mainCamera;

    private void Awake()
    {
        mainCamera = cameras[1];
    }

    public void OnClick(int number)
    {
        Debug.Log("OnClick " + number);  
        SwitchTo(cameras[number]);
    }
    void SwitchTo(CinemachineCamera target)
    {
        Debug.Log("SwitchTo");
        Debug.Log(mainCamera + "11");
        if (target == null || target == mainCamera) return;
        if (mainCamera != null) mainCamera.Priority = 10;
        mainCamera = target;
        Debug.Log(mainCamera);
        target.Priority = 20;
    }
}
