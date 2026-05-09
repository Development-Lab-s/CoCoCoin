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
    [SerializeField] private GameObject stopCanvas;
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
        if (instance == null)
        {
            instance = this;
            Settingframe.SetActive(false);
            esc.SetActive(false);
            stopCanvas.GetComponent<Canvas>().sortingOrder = 2;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(stopCanvas);
        }
        else
        {
            Destroy(stopCanvas);
            Destroy(gameObject);
        }
    }

    public void Backtogame()
    {
        esc.SetActive(!esc.activeSelf);

    }

    public void setting()
    {
        Settingframe.SetActive(!Settingframe.activeSelf);

    }

    public void Restart()
    {
        esc.SetActive(false);
        MapManager.isInitialized = false;
        MapManager.saveMapId = null;
        _ = SceneManageHandler.instance.MoveScene(0);
    }
}
