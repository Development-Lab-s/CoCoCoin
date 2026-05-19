using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;

public class WalkCam : MonoBehaviour
{
    public Transform target;   
    public float moveDistance = 5f; 
    public float moveDuration = 3f;   
    
    public float bobHeight = 0.08f;  
    public float bobFrequency = 2.2f;
    public float camExpand = 0.02f;

    private CinemachineCamera _cam;
    private Vector3 _startPos;
    private Sequence _seq;
    private float _remember;

    void Start()
    {
        _cam = GetComponent<CinemachineCamera>();
        _startPos = transform.position;
        _cam.Lens.OrthographicSize = 7.3f;
    }

    public void Play(bool expand)
    {
        _seq?.Kill();
        _seq = DOTween.Sequence();

        if (expand == false)
            _cam.Lens.OrthographicSize = _remember;
        Vector3 forward = target != null
            ? (target.position - _startPos).normalized * moveDistance
            : transform.forward * moveDistance;

        _seq.Append(
            transform.DOMove(_startPos + forward, moveDuration)
                     .SetEase(Ease.InOutSine)
        );

        
        float elapsed = 0f;
        Vector3 basePos = _startPos;

        _seq.Join(
            DOTween.To(() => elapsed, v => elapsed = v, moveDuration, moveDuration)
                   .SetEase(Ease.Linear)
                   .OnUpdate(() =>
                   {
                       if (expand == true) 
                           _cam.Lens.OrthographicSize -= camExpand;
                       else
                           _cam.Lens.OrthographicSize += camExpand;

                       float t = elapsed / moveDuration;
                       basePos = Vector3.Lerp(_startPos, _startPos + forward, t);


                       float phase  = elapsed * bobFrequency * Mathf.PI * 2f; // 발걸음 파트
                       float yBob   = Mathf.Abs(Mathf.Sin(phase)) * bobHeight;

                       transform.position = basePos + new Vector3(0f, yBob, 0f);
                       
                   })
        );

        _seq.OnComplete(() =>
        {
            transform.position = _startPos;
            _remember = _cam.Lens.OrthographicSize;
            _cam.Lens.OrthographicSize = 7.3f;
        });
    }
    
    public void ResetCamera()
    {
        _seq?.Kill();
        transform.position = _startPos;
        _cam.Lens.OrthographicSize = 7.3f;
    }

    void OnDestroy() => _seq?.Kill();
}