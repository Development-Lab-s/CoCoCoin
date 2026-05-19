using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinDrag : MonoBehaviour
{
    public InventoryItemSO so;
    private SpriteRenderer _sr;
    [Header("Settings")]
    [SerializeField] private float _maxScale = 1.3f;
    [SerializeField] private float _scaleSpeed = 10f;
    [SerializeField] private float _returnSpeed = 15f;
     private LayerMask _targetLayer; // 목표 지점의 레이어

    private Vector3 _originalPosition;
    private Vector3 _originalScale;
    public static bool _isDragging = false;
    private static int coinCount = 0;
    private Coroutine _scaleCoroutine;
    private Coroutine _moveCoroutine;

    private CoinMover _coinMover;

    private ToolTip toolTip;

    void OnMouseEnter()
    {
        
        toolTip.ShowToolTip(so.Name, so.Description, transform.position, so.Sprite,so.rarity);
    }

    void OnMouseExit()
    {
        toolTip.HideToolTip();
    }

    private void Start()
    {
        _originalPosition = transform.position;
        _originalScale = transform.localScale;
    }


    public void Init(InventoryItemSO itemSo)
    {
        _sr = GetComponent<SpriteRenderer>();
        _coinMover = GameObject.Find("CoinMover").GetComponent<CoinMover>();
        toolTip = GameObject.Find("DrawingChipCanvas").GetComponent<ToolTip>();
        if (_targetLayer == 0)
        {
            _targetLayer = LayerMask.GetMask("OutPoint");
        }
        so = itemSo;
        _sr.sprite = so.Sprite;
        
    }

    private void OnMouseDown()
    {
        toolTip.HideToolTip();
        _isDragging = true;
        _sr.sortingLayerName = "Dragging";

        // 이동 중이었다면 멈춤
        if (_moveCoroutine != null) StopCoroutine(_moveCoroutine);

        // 커지는 효과 시작
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

        // 드롭 위치에 목표 지점이 있는지 체크 (Collider2D 필요)
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.5f, _targetLayer);
        _sr.sortingLayerName = "Default";
        if (hit != null)
        {
            //목표 지점이면 파괴
            coinCount++;
            Destroy(gameObject);
            _coinMover.Select(so);
            if (coinCount == 3)
            {
                _ = SceneManageHandler.instance.MoveScene(1);
                coinCount = 0;
            }
        }
        else
        {
            toolTip.ShowToolTip(so.Name, so.Description, transform.position, so.Sprite,so.rarity);
            // 목표 지점이 아니면 복귀 및 크기 복원
            StartScaleEffect(_originalScale);
            _moveCoroutine = StartCoroutine(RoutineReturnToOrigin());
        }
    }

    // --- 연출용 함수들 ---

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