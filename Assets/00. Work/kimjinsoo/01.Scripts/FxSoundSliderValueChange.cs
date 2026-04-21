using UnityEngine;
using UnityEngine.UI;

public class FxSoundSliderValueChange : MonoBehaviour
{
    private Slider slider;
    

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = DataSingleTon.Instance.fxSliderValue;
    }
}
