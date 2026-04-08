using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    private Animator animator;

    [Header("References")]
    public CoinController coinScript; // 코인 스크립트를 연결할 빈칸!
    public Transform palmPoint;       // 동전이 나타날 손바닥 위치(빈 오브젝트)를 연결할 빈칸!

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 마우스 왼쪽 버튼(또는 모바일 화면 터치)을 누르면 애니메이션 시작
        if (Input.GetMouseButtonDown(0))
        {
            // 애니메이터에 설정해 둔 트리거 이름 (이름은 에디터 설정에 맞게 수정 가능)
            animator.SetTrigger("isDie");
        }
    }

    // 🎬 애니메이션 이벤트 1: 손 애니메이션 타임라인에서 '낚아챌 때' 호출
    public void OnCatchEvent()
    {
        if (coinScript != null)
        {
            coinScript.HideCoin(); // 코인에게 숨으라고 명령!
        }
    }

    // 🎬 애니메이션 이벤트 2: 손 애니메이션 타임라인에서 '손을 쫙 펼 때' 호출
    public void OnOpenHandEvent()
    {
        if (coinScript != null && palmPoint != null)
        {
            // 코인에게 내 손바닥 위치(palmPoint.position)를 넘겨주며 나타나라고 명령!
            coinScript.ShowResult(palmPoint.position);
        }
    }
}