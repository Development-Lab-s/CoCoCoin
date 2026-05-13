using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAnotherScene : MonoBehaviour
{
    public void Change()
    {
        //Setting
        GameData.instance.playerCurrentHp = 100;
        _ = SceneManageHandler.instance.MoveScene(1);
    }
}
