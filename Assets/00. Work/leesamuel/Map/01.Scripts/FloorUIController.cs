using UnityEngine;
using TMPro;
using System.Collections;

public class FloorUIController : MonoBehaviour
{
    public TextMeshProUGUI floorText;
    public CanvasGroup canvasGroup;
    public AnimationCurve bounceCurve;

    [Header("시간 설정")]
    public float totalDuration = 1.5f; // 전체 진행 시간을 1.5초로 설정
    public float holdTime = 1.0f;      // 나타난 후 멈춰있는 시간

    public void ShowFloorUI(int floorNumber)
    {
        StopAllCoroutines();
        floorText.text = "Floor " + floorNumber;

        // 초기화
        floorText.transform.localScale = Vector3.zero;
        if (canvasGroup != null) canvasGroup.alpha = 0f;

        StartCoroutine(LightweightRoutine());
    }

    private IEnumerator LightweightRoutine()
    {
        float elapsed = 0f;

        // 1. 나타나는 단계 (totalDuration 동안 진행)
        while (elapsed < totalDuration)
        {
            elapsed += Time.deltaTime;

            // 0~1 사이의 비율 계산 (현재 시간 / 1.5초)
            float t = elapsed / totalDuration;

            // 그래프에서 해당 비율의 값을 가져와 크기에 적용
            float scale = bounceCurve.Evaluate(t);
            floorText.transform.localScale = Vector3.one * scale;

            // 투명도도 같이 조절 (0에서 1로)
            if (canvasGroup != null) canvasGroup.alpha = Mathf.Min(t * 2, 1f);

            yield return null;
        }

        // 2. 잠시 대기
        yield return new WaitForSeconds(holdTime);

        // 3. 사라지는 단계 (가볍게 위로 날아감)
        elapsed = 0f;
        float fadeOutTime = 0.4f;
        Vector3 startPos = floorText.transform.localPosition;
        Vector3 endPos = startPos + new Vector3(0, 150, 0);

        while (elapsed < fadeOutTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeOutTime;

            floorText.transform.localPosition = Vector3.Lerp(startPos, endPos, t);
            if (canvasGroup != null) canvasGroup.alpha = 1f - t;

            yield return null;
        }

        // 다음을 위해 위치 리셋
        floorText.transform.localPosition = startPos;
    }
}