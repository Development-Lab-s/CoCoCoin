using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void ShopExit()
    {
        SceneManageHandler.instance.MoveScene(1);
    }
}
