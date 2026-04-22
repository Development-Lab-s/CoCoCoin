using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataSingleTon : MonoBehaviour
{
    public static DataSingleTon instance;
    private GameObject musicSliderOrigin;
    private GameObject fxSliderOrigin;
    private Slider musicSlider;
    private Slider fxSlider;
    public float musicSliderValue = 10f;
    public float fxSliderValue = 10f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }        
    }

    private void Start()
    {
        
        fxSliderOrigin = GameObject.Find("FXSound Slider");
        musicSliderOrigin = GameObject.Find("Sound Slider");
        musicSlider = musicSliderOrigin.GetComponent<Slider>();
        fxSlider = fxSliderOrigin.GetComponent<Slider>();
        
    }

    private void Update()
    {
        fxSliderValue = fxSlider.value;
        musicSliderValue = musicSlider.value;
    }

}

