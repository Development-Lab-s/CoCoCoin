using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnOffItself : MonoBehaviour
{
    [SerializeField] private GameObject button;

    private void Update()
    {
        if(ScreenManager.instance.esc.activeSelf == false)
        {
            button.SetActive(true);
            //Time.deltaTime = 0;
        }
        else if (ScreenManager.instance.esc.activeSelf == true)
        {
            button.SetActive(false);
            //Time.deltaTime = 1;
        }
    }

    private void Start()
    {
        button.SetActive(true);
    }
}
