using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipDraw : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private InventoryToolTip toolTip;
    private InventoryItemSO chip = null;
    private Transform chipUI;
    private Image image;
    private Vector3 startPosition;
    private CanvasGroup canvasGroup;

    private Vector2 minRange;
    private Vector2 maxRange;

    Rigidbody2D coinRigid;
    Animator handAnimator;
    Animator coinAnimator;


    private void Awake()
    {
        image = GetComponentInChildren<Image>();
        canvasGroup = GetComponentInParent<CanvasGroup>();
    }

    private void Start()
    {
        minRange = new Vector2(-2, -2);
        maxRange = new Vector2(2, 2);
    }

    public void Init(InventoryToolTip toolTip, InventoryItemSO chip, Transform chipUI, Rigidbody2D coinRigid, Animator handAnimator, Animator coinAnimator)
    {
        this.toolTip = toolTip;
        this.chip = chip;
        this.chipUI = chipUI;
        this.coinRigid = coinRigid;
        this.handAnimator = handAnimator;
        this.coinAnimator = coinAnimator;
        image.sprite = chip.SpriteOnStack;
        image.color = new Color(0,0,0,0);
        image.DOColor(Color.gray, 0.5f);
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
            chipModel.GetComponentInChildren<Image>().DOColor(Color.gray, 0.1f);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(chipUI.parent);
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        canvasGroup.blocksRaycasts = false;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < maxRange.x && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < maxRange.y && Camera.main.ScreenToWorldPoint(Input.mousePosition).x > minRange.x && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > minRange.y)
        {
            BattleManager.instance.DiscardChip(chip);
            BattleManager.instance.UseChip(chip,gameObject);
            
        }
        else
        {
            transform.SetParent(chipUI);
        }
    }

    private void OnDestroy()
    {
        DOTween.Kill(image);
        canvasGroup.blocksRaycasts = true;
        toolTip.HideToolTip();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
    }
}
