using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataSingleTon : MonoBehaviour
{
    public static DataSingleTon Instance;
    private GameObject musicSliderOrigin;
    private GameObject fxSliderOrigin;
    private Slider musicSlider;
    private Slider fxSlider;
    public float musicSliderValue;
    public float fxSliderValue;
    private bool inFirstScene;

    private void Start()
    {
        Instance = this;
        fxSliderOrigin = GameObject.Find("FXSound Slider");
        musicSliderOrigin = GameObject.Find("Sound Slider");
        musicSlider = musicSliderOrigin.GetComponent<Slider>();
        fxSlider = fxSliderOrigin.GetComponent<Slider>();
        
    }

    private void Update()
    {
        /*if(inFirstScene == false)
        {
            fxSliderOrigin = GameObject.Find("FXSound Slider");
            musicSliderOrigin = GameObject.Find("Sound Slider");
            musicSlider = musicSliderOrigin.GetComponent<Slider>();
            fxSlider = fxSliderOrigin.GetComponent<Slider>();
            inFirstScene = true;        }*/
        
        fxSliderValue = fxSlider.value;
        musicSliderValue = musicSlider.value;
    }

    public void MoveOnNextScene()
    {
        DontDestroyOnLoad(gameObject);
        inFirstScene = false;
    }

}

