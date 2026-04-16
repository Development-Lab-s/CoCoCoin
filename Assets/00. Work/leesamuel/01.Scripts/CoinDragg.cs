using UnityEngine;
using System.Collections;

public class CoinDragg : MonoBehaviour
{
    [SerializeField] private InventoryItemSO so;
    private SpriteRenderer _sr;
    [Header("Settings")]
    [SerializeField] private float _maxScale = 1.5f;
    [SerializeField] private float _scaleSpeed = 10f;
    [SerializeField] private float _returnSpeed = 15f;
     private LayerMask _targetLayer; // 목표 지점의 레이어

    private Vector3 _originalPosition;
    private Vector3 _originalScale;
    private bool _isDragging = false;
    private Coroutine _scaleCoroutine;
    private Coroutine _moveCoroutine;

    private CoinMover _coinMover;

 
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _originalPosition = transform.position;
        _originalScale = transform.localScale;
        _coinMover = GameObject.Find("CoinMover").GetComponent<CoinMover>();
        if (_targetLayer == 0)
        {
            _targetLayer = LayerMask.GetMask("OutPoint");
        }
    }

    private void OnMouseDown()
    {
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
            Destroy(gameObject);
            _coinMover.Select(so);
        }
        else
        {
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