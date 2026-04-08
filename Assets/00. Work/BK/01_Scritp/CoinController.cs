
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [Header("Coin Settings")]
    public Sprite headsSprite;        // 동전 앞면 이미지
    public Sprite tailsSprite;        // 동전 뒷면 이미지

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        // 자기 자신의 SpriteRenderer 컴포넌트를 가져옵니다.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 감독(손)이 "숨어!" 하고 명령할 때 실행될 함수
    public void HideCoin()
    {
        gameObject.SetActive(false);
    }

    // 감독(손)이 "나타나!" 하고 위치를 알려주면 실행될 함수
    public void ShowResult(Vector3 targetPosition)
    {
        // 1. 전달받은 손바닥 위치로 순간이동
        transform.position = targetPosition;

        // 2. 랜덤 앞/뒷면 확률 계산 (0 이상 2 미만의 정수 -> 0 또는 1)
        int randomCoin = Random.Range(0, 2);
        if (randomCoin == 0)
        {
            spriteRenderer.sprite = headsSprite;
            Debug.Log("결과: 앞면!");
        }
        else
        {
            spriteRenderer.sprite = tailsSprite;
            Debug.Log("결과: 뒷면!");
        }

        // 3. 짠! 하고 화면에 나타남
        gameObject.SetActive(true);
    }
}