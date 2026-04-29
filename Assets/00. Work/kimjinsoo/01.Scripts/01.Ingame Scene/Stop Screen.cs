using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject esc;
    [SerializeField] private GameObject Settingframe;
    public static ScreenManager instance;
    private bool isActive;
    private bool timeScaleValue;
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            //esc.SetActive(!esc.activeSelf);  
            Backtogame();
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
        if(esc.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;

    }

    public void setting()
    {
        Settingframe.SetActive(!Settingframe.activeSelf);

    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
