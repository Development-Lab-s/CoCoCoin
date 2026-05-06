using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAnotherScene : MonoBehaviour
{
    public void Change()
    {
         SceneManageHandler.instance.MoveScene(1);
    }
}
