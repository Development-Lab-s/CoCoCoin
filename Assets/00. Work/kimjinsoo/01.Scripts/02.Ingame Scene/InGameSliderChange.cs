using UnityEngine;
using UnityEngine.UI;

public class InGameSliderChange : MonoBehaviour
{
    private Slider slider;
    


    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = DataLoadManager.instance.musicSoundValue;
    }

    void Update()
    {
        //slider.value = DataLoadManager.instance.musicSoundValue;
    }
}
