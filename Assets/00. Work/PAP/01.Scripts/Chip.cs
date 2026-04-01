using System;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour
{
    private InventoryItemSO item;
    private Image image;

    public void Init(InventoryItemSO item)
    {
        this.item = item;
        image.sprite = item.Sprite; // 이거 지금 안됨
    }

    public void OnMouseEnter()
    {
        //칩 이름 & 설명 보여주기
        Debug.Log($"이름 : {item.Name} 설명 : {item.Description}");
    }
}
