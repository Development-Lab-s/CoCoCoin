using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataSingleTon : MonoBehaviour
{
    public static DataSingleTon instance;
    [SerializeField]private GameObject musicSliderOrigin;
    [SerializeField]private GameObject fxSliderOrigin;
    private Slider musicSlider;
    private Slider fxSlider;
    public float musicSliderValue = 10f;
    public float fxSliderValue = 10f;
    [SerializeField] AudioMixer audioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }       
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicSlider = musicSliderOrigin.GetComponent<Slider>();
        fxSlider = fxSliderOrigin.GetComponent<Slider>();
    }
    private void Update()
    {
        fxSliderValue = fxSlider.value;
        musicSliderValue = musicSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(fxSliderValue) * 20);
        audioMixer.SetFloat("BGM", Mathf.Log10(fxSliderValue) * 20);
    }
}

