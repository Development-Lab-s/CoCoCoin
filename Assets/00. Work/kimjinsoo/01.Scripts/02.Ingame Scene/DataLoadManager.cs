using UnityEngine;

public class DataLoadManager : MonoBehaviour
{
    public static DataLoadManager instance;
    public float fxSoundValue;
    public float musicSoundValue;
    
    private void Start()
    {
        instance = this;
        fxSoundValue = DataSingleTon.Instance.fxSliderValue;
        musicSoundValue = DataSingleTon.Instance.musicSliderValue;

    }
}
