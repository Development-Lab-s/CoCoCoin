using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitMotion;

public class ChipItem : MonoBehaviour
{
    private InventoryItemSO item;
    private InventoryToolTip toolTip;
    private SpriteRenderer image;
    private Vector3 originalPosition;
    private Vector3 newPosition;


    public void Init(InventoryItemSO item,InventoryToolTip toolTip)
    {
        this.item = item;
        this.toolTip = toolTip;
        originalPosition = transform.position;
        newPosition = transform.position + new Vector3(0,0.1f,0);
        Transform rectTrm = GetComponent<Transform>();
        image = GetComponent<SpriteRenderer>();
        image.sprite = item.SpriteOnInventory;
        gameObject.name = item.Name;
        rectTrm.localScale = Vector3.one;
    }


    public void OnMouseEnter()
    {
        //칩 이름 & 설명 보여주기
        StartCoroutine(MoveObject(newPosition, 0.1f));
        Vector2 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        toolTip.ShowToolTip(item.Name, item.Description, screenPos, item.Sprite);
    }

    public void OnMouseExit()   
    {
        StartCoroutine(MoveObject(originalPosition, 0.1f));
        toolTip.HideToolTip();
    }

    public void OnMouseDown()
    {
        item.ChipEncounter.FlipCoin();
    }

    IEnumerator MoveObject(Vector3 targetPosition, float duration)
    {
        float timeElasped = 0;
        Vector3 startPosition = transform.position;

        while (timeElasped < duration)
        {
            float t = timeElasped / duration;
            MotionHandle handle = LMotion.Create(0f, 1f, 0.25f).Bind(v => Debug.Log(v));

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            timeElasped += Time.deltaTime;

            yield return null;
        }
        transform.position = targetPosition;
    }
}
