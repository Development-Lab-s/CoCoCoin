using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject esc;
    [SerializeField] private GameObject Settingframe;
    public static ScreenManager instance;
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
        instance = this;
        esc.SetActive(false);
        Settingframe.SetActive(false);
    }

    public void Backtogame()
    {
        esc.SetActive(!esc.activeSelf);
    }

    public void setting()
    {
        Settingframe.SetActive(!Settingframe.activeSelf);
    }
}
