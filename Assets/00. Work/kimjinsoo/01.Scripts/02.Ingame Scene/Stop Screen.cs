using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject esc;
    [SerializeField] private GameObject Settingframe;
    private bool isActive;

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        { 
                esc.SetActive(!esc.activeSelf);
        }
    }

    private void Start()
    {
        esc.SetActive(false);
        Settingframe.SetActive(false);
    }

    public void Backtogame()
    {
        esc.SetActive(false);
    }

    public void setting()
    {
        Settingframe.SetActive(!Settingframe.activeSelf);
    }
}
