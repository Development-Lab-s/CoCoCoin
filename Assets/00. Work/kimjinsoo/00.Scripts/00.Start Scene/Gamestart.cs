using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Gamestart : MonoBehaviour
{

    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject start;
    private float time;
    private void Start()
    {
        exit.SetActive(false);
        setting.SetActive(false);
        start.SetActive(false);


    }
    public void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            /*start.SetActive(true);
            exit.SetActive(true);
            setting.SetActive(true);
            gameObject.SetActive(false);*/
            StartGameYeah();

        }
    }
    public void StartGameYeah()
    {
        SceneManager.LoadScene("01.Loading");
    }
}
