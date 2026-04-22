using Unity.VisualScripting;
using UnityEngine;

public class OnButtonDetect : MonoBehaviour
{
    [SerializeField] private RectTransform finger;
    [SerializeField] private RectTransform originPoint;

    private void OnMouseExit()
    {
        finger.position = transform.position;
        Debug.Log(finger.transform.position);
    }


    private void OnMouseDown()
    {
        finger.position = originPoint.position;
        Debug.Log(finger.transform.position);
    }
}