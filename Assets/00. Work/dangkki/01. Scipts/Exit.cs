using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public WalkCam WalkCam;
    public void ShopExit()
    {
        WalkCam.target = transform;
        WalkCam.moveDistance = 50;
        WalkCam.moveDuration = 1f;
        WalkCam.camExpand = 0.05f;
        WalkCam.Play(true);
        SceneManageHandler.instance.MoveScene(1);
    }
}
