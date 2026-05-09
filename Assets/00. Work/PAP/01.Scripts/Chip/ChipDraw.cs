using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipDraw : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private InventoryToolTip toolTip;
    public InventoryItemSO chip = null;
    private Transform chipUI;
    [SerializeField]private Image image;
    [SerializeField] private Image detectiveImage;
    [SerializeField]
    Material[] materials = new Material[3];
    Dictionary<InventoryItemSO.Rarity, Material> rarityColor;




    public void Init(InventoryToolTip toolTip, InventoryItemSO chip, Transform chipUI)
    {
        rarityColor = new Dictionary<InventoryItemSO.Rarity, Material>()
        {
            { InventoryItemSO.Rarity.Common, materials[0] },
            { InventoryItemSO.Rarity.Rare, materials[1] },
            { InventoryItemSO.Rarity.Legendary, materials[2] }
        };
        this.toolTip = toolTip;
        this.chip = chip;
        this.chipUI = chipUI;
        image.sprite = chip.SpriteOnStack;
        image.color = new Color(0,0,0,0);
        image.DOColor(Color.gray, 0.5f);
        image.material = rarityColor[chip.rarity];
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.ShowToolTip(chip.Name, chip.Description, transform.position + new Vector3(2,1,0), chip.Sprite);
        image.DOColor(Color.white, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.HideToolTip();
        foreach (Transform chipModel in chipUI)
        {
            foreach (Transform child in chipModel)
            {
                child.GetComponent<Image>().DOColor(Color.gray, 0.1f);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(chipUI.parent);
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        detectiveImage.raycastTarget = true;
        transform.SetParent(chipUI);
    }

    private void OnDestroy()
    {
        DOTween.Kill(image);
        toolTip.HideToolTip();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        detectiveImage.raycastTarget = false;
    }
}
