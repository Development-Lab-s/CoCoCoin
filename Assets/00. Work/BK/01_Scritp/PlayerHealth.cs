using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;     // 최대 체력
    private float currentHealth;       // 현재 체력
    public Image healthBarFill;        // UI 체력바 이미지 연결칸

    void Start()
    {
        // 시작할 때 체력을 꽉 채우고 시작합니다.
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // [테스트용] 스페이스바 누르면 10씩 깎임 (나중에 지우시면 됩니다)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10f);
        }
    }

    // 외부에서 공격할 때 사용하는 필수 함수
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 0 밑으로 안 떨어지게 방어

        UpdateHealthBar(); // UI 업데이트

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // UI 이미지를 실제 체력 비율에 맞게 줄여주는 필수 함수
    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        Debug.Log("플레이어 사망!");
    }
}