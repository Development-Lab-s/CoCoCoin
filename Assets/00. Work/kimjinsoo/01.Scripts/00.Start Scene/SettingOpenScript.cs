using UnityEngine;
using DG.Tweening;

public class SettingOpenScript : MonoBehaviour
{
    private GameObject settingFrame;
    private bool settingFrameIsTurned = false;

    private void Start()
    {
        settingFrame = GameObject.Find("SettingFrame");
        settingFrame.SetActive(false);
    }


    public void setting()
    {
        settingFrame.SetActive(!settingFrame.activeSelf);
       /* settingFrame.transform.DOScale(new Vector2(1.2f,1.2f), 0.4f);
        settingFrameIsTurned = true;*/

    }

   /* private void Update()
    {
        if(settingFrameIsTurned == true)
        {
            settingFrame.transform.DOScale(new Vector2(1.0f, 1.0f), 0.4f);
            settingFrameIsTurned =false;
        }
    } */

}
