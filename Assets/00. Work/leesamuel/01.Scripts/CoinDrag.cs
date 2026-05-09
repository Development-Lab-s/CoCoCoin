using System.Collections;
using UnityEngine;

public class CoinDrag : MonoBehaviour
{
    private InventoryItemSO so;

    private SpriteRenderer _sr;
    [Header("Settings")]
    [SerializeField] private float _maxScale = 1.3f;
    [SerializeField] private float _scaleSpeed = 10f;
    [SerializeField] private float _returnSpeed = 15f;
    private LayerMask _targetLayer;

    private Vector3 _originalPosition;
    private Vector3 _originalScale;
    public static bool _isDragging = false;
    private static int coinCount = 0;
    private Coroutine _scaleCoroutine;
    private Coroutine _moveCoroutine;
    private ToolTip toolTip;

    public void Setup(InventoryItemSO itemSO)
    {
        so = itemSO;
    }

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _originalPosition = transform.position;
        _originalScale = transform.localScale;
        toolTip = GameObject.Find("DrawingChipCanvas").GetComponent<ToolTip>();
        if (_targetLayer == 0)
        {
            _targetLayer = LayerMask.GetMask("OutPoint");
        }
    }

    void OnMouseEnter()
    {
        if (so != null)
            toolTip.ShowToolTip(so.Name, so.Description, transform.position, so.Sprite);
    }

    void OnMouseExit()
    {
        toolTip.HideToolTip();
    }

    private void OnMouseDown()
    {
        toolTip.HideToolTip();
        _isDragging = true;
        _sr.sortingLayerName = "Dragging";
        if (_moveCoroutine != null) StopCoroutine(_moveCoroutine);
        StartScaleEffect(_originalScale * _maxScale);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        _isDragging = false;
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.5f, _targetLayer);
        _sr.sortingLayerName = "Default";

        if (hit != null)
        {
            coinCount++;
            Select(so);
            Destroy(gameObject);
            if (coinCount == 3) Debug.Log("씬 넘어가기");
        }
        else
        {
            if (so != null)
                toolTip.ShowToolTip(so.Name, so.Description, transform.position, so.Sprite);
            StartScaleEffect(_originalScale);
            _moveCoroutine = StartCoroutine(RoutineReturnToOrigin());
        }
    }

    public void Select(InventoryItemSO item)
    {
        if (item != null)
            GameManager.instance.inventoryManager.AddItem(item);
    }

    private void StartScaleEffect(Vector3 targetScale)
    {
        if (_scaleCoroutine != null) StopCoroutine(_scaleCoroutine);
        _scaleCoroutine = StartCoroutine(RoutineScale(targetScale));
    }

    private IEnumerator RoutineScale(Vector3 targetScale)
    {
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * _scaleSpeed);
            yield return null;
        }
        transform.localScale = targetScale;
    }

    private IEnumerator RoutineReturnToOrigin()
    {
        while (Vector3.Distance(transform.position, _originalPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, _originalPosition, Time.deltaTime * _returnSpeed);
            yield return null;
        }
        transform.position = _originalPosition;
    }
}
