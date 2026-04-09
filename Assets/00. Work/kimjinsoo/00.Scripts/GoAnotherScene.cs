using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAnotherScene : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("Loading");
    }
}
