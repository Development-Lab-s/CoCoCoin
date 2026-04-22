using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class InGameFxSliderChange : MonoBehaviour
{
    private Slider slider;

    void Update()
    {
        //slider.value = DataLoadManager.instance.fxSoundValue;
    }

    private void OnEnable()
    {
        
            slider = GetComponent<Slider>();
            slider.value = DataSingleTon.instance.fxSliderValue;
        
    }
}
