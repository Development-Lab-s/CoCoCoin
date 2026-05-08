using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAnotherScene : MonoBehaviour
{
    public void Change()
    {
        //Setting
        GameData.instance.playerMaxHp = 100;
        GameData.instance.playerCurrentHp = 100;
         SceneManageHandler.instance.MoveScene(1);
    }
}
