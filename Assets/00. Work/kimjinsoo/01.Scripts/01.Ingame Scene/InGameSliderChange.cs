using UnityEngine;
using UnityEngine.UI;

public class InGameSliderChange : MonoBehaviour
{
    private Slider slider;
    
    
    void Update()
    {
        //slider.value = DataSingleTon.instance.musicSliderValue;
    }
    
    private void OnEnable()
    {
        
            
        slider = GetComponent<Slider>();
        slider.value = DataSingleTon.instance.musicSliderValue;
        
    }
}
