using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f; // 적의 체력

    // 적이 데미지를 받는 스위치 (아까 플레이어랑 똑같습니다!)
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("적 맞음! 남은 체력: " + health);

        if (health <= 0)
        {
            Debug.Log("적 처치!");
            Destroy(gameObject); // 체력이 0이 되면 적 오브젝트를 화면에서 삭제합니다.
        }
    }
}
