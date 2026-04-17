using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private TextMeshProUGUI textmeshprougui;
    [SerializeField]private float time = 4.0f;
    

    public void Start()
    {
        textmeshprougui = GetComponent<TextMeshProUGUI>();
        textmeshprougui.text = "Loading.";
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if(time <= 2.0f)
        {
            textmeshprougui.text = "Loading..";
        }
        if (time <= 1.0f)
        {
            textmeshprougui.text = "Loading....";
        }
        if (time <= 0)
        {
            SceneManager.LoadScene("02.InGame");
            Debug.Log("Sent to ingame scene");
        }       
    }
}
