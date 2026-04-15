using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipDraw : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryToolTip toolTip;
    private InventoryItemSO chip = null;
    private Transform chipUI;
    
    public void Init(InventoryToolTip toolTip, InventoryItemSO chip, Transform chipUI)
    {
        this.toolTip = toolTip;
        this.chip = chip;
        this.chipUI = chipUI;
        GetComponentInChildren<Image>().color = Color.gray;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.ShowToolTip(chip.Name, chip.Description, gameObject.transform.position + new Vector3(200,400), chip.Sprite);
        StartCoroutine(ColorObject(GetComponentInChildren<Image>(), Color.white, 0.1f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.HideToolTip();
        foreach (Transform chipModel in chipUI)
        {
            StartCoroutine(ColorObject(chipModel.GetComponentInChildren<Image>(), Color.gray, 0.1f));
        }
    }

    IEnumerator ColorObject(Image image, Color targetColor, float time)
    {
        Color startColor = image.color;
        float elaspedTime = 0f;
        while (elaspedTime < time)
        {
            elaspedTime += Time.deltaTime;

            image.color = Color.Lerp(startColor, targetColor, elaspedTime / time);
            yield return null;
        }

        image.color = targetColor;

    }
}
