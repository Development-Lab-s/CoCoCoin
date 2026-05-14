using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAnotherScene : MonoBehaviour
{
    public void Change()
    {
        Set();
        _ = SceneManageHandler.instance.MoveScene(1);
    }
    
    public void TutoChange()
    {
        Set();
        _ = SceneManageHandler.instance.MoveScene(6);
    }

    private void Set()
    {
        GameData.instance.playerCurrentHp = 100;
    }
}
