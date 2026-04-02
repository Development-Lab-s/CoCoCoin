using UnityEngine;

public class AttackButton : MonoBehaviour
{
    [Header("누구를 때릴 것인가?")]
    public EnemyHealth targetEnemy; // 때릴 적을 연결할 칸

    [Header("버튼의 공격력")]
    public float attackPower = 10f; // 버튼 한 번 누를 때 들어갈 데미지

    // 마우스로 버튼을 클릭할 때 실행될 함수입니다.
    public void OnAttackButtonClicked()
    {
        if (targetEnemy != null)
        {
            targetEnemy.TakeDamage(attackPower); // 적의 스위치를 원격으로 누름!
        }
    }
}