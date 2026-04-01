using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI를 제어하기 위해 꼭 필요해요!

public class Unit : MonoBehaviour
{
    private string unitName;   // 이름
    public int hp;            // 현재 체력
    public int MaxHp;         // 최대 체력
    public int power;   // 공격력
    [SerializeField] private Text hpText;       // 연결할 숫자 UI 텍스트
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
        HPUI();
    }
    private void HPUI()
    {
        hpText.text = "HP : " + hp + " / " + MaxHp;
    }
    public void Damage(int damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0;
        HPUI();
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // 아주 짧은 시간 동안 무작위 위치로 이동
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null; // 다음 프레임까지 대기
        }
    }
}