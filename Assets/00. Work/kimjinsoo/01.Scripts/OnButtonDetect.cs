using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    private float delayTime = 0.1f;
    private Vector3 currentPos;

    private void Start()
    {
        currentPos = transform.localScale;
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;

    }

    public void MouseClicked()
    {
        transform.localScale = new Vector3(0.12f, 0.12f, 0);
        StartCoroutine(DelayCorutine());
    }

    private IEnumerator DelayCorutine()
    {
        yield return new WaitForSeconds(delayTime);
        transform.localScale = currentPos;
    }
}