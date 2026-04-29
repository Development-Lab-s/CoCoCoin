using UnityEngine;

public class SettingOpenScript : MonoBehaviour
{


    private GameObject Settingframe;

    private void Start()
    {
        Settingframe = GameObject.Find("SettingFrame");
        Settingframe.SetActive(false);
    }


    public void setting()
    {
        Settingframe.SetActive(!Settingframe.activeSelf);
    }
}
