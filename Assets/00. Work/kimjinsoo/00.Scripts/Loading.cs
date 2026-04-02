using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private TextMeshProUGUI textmeshprougui;
    [SerializeField]private float time = 1.0f;
    

    public void Start()
    {
        textmeshprougui = GetComponent<TextMeshProUGUI>();
        textmeshprougui.text = "Loading...";
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene("UI");
        }       
    }
}
