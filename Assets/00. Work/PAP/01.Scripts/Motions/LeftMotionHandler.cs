using DG.Tweening;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class LeftMotionHandler : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] Animator animator;
    [SerializeField] TipUIHandler tipUIHandler;
    Vector3 targetPos = new Vector3(-4, -4.5f, 0);
    Vector3 originPos = new Vector3(-6  , -9f, 0);

    int turnHash = Animator.StringToHash("Turn");

    private void Awake()
    {
        transform.position = originPos;
        gameObject.SetActive(false);
    }
    public void PlayMotion(int motionId)
    {
        gameObject.SetActive(true);
        switch (motionId)
        {
            case 0:
                StartCoroutine(TurnMotion());
                break;
            case 1:
                StartCoroutine(TurnBackMotion());
                break;
        }
    }


    private IEnumerator TurnMotion()
    {
        animator.SetBool(turnHash, true);
        transform.DOMove(targetPos, 0.5f);
        tipUIHandler.ShowTrashTip();
        yield return new WaitForSeconds(0);
    }

    private IEnumerator TurnBackMotion()
    {
        animator.SetBool(turnHash, false);
        transform.DOMove(originPos, 0.5f).OnComplete(()=>gameObject.SetActive(false));
        tipUIHandler.HideTrashTip();
        yield return new WaitForSeconds(0);
    }
}
