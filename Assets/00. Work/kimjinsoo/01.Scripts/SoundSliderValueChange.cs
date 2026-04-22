using UnityEngine;
using UnityEngine.UI;

public class SoundSliderValueChange : MonoBehaviour
{
    private Slider slider;


    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = DataSingleTon.instance.musicSliderValue;
    }
}
