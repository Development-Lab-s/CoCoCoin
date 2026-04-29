using UnityEngine;
using UnityEngine.UI;

public class UIDataManager : MonoBehaviour
{

    private GameObject musicSliderOrigin;
    private GameObject fxSliderOrigin;
    private Slider musicSlider;
    private Slider fxSlider;
    public float musicSliderValue = 10f;
    public float fxSliderValue = 10f;

    private void Start()
    {
        fxSliderOrigin = GameObject.Find("FXSound Slider");
        musicSliderOrigin = GameObject.Find("Sound Slider");
        Debug.Log("Setting has been set");
    }

    /*private void Update()
    {
            fxSliderValue = fxSlider.value;
            musicSliderValue = musicSlider.value;
    }*/
}
