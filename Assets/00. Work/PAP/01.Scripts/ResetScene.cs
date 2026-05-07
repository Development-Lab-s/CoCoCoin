using UnityEngine;

namespace _00._Work.PAP._01.Scripts
{
    public class ResetScene : MonoBehaviour
    {
        public void ResetAll()
        {
            MapManager.isInitialized = false;
            MapManager.saveMapId = null;
            SceneManageHandler.instance.MoveScene(0);
        }
    }
}