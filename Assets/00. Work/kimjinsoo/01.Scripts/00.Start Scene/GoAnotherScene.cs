using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAnotherScene : MonoBehaviour
{
    private void Set()
    {
        GameData.instance.playerMaxHp = 100;
        GameData.instance.playerCurrentHp = 100;
    }
    public void Change()
    {
        Set();
        _ = SceneManageHandler.instance.MoveScene(1);
    }

    public void ChangeTutorial()
    {
        Set();
        
    }
}
