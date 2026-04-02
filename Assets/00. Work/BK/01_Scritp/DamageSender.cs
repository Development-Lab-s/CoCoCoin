using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [Header("누구에게 신호를 보낼 것인가?")]
    // 질문자님이 만든 PlayerHealth 스크립트를 직접 가리키는 조준점 역할을 합니다.
    public PlayerHealth targetPlayer;

    [Header("얼마나 깎을 것인가?")]
    public float attackPower = 10f;

    void Update()
    {
        // 키보드의 'Z' 키(버튼)를 누르는 순간 작동합니다.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 만약 타겟(플레이어)이 잘 연결되어 있다면?
            if (targetPlayer != null)
            {
                // 플레이어의 TakeDamage 스위치를 누르며 데미지 숫자를 넘겨줍니다!
                targetPlayer.TakeDamage(attackPower);

                // 유니티 콘솔창에 신호를 보냈다고 텍스트를 띄웁니다.
                Debug.Log("HIT 신호 발사! 데미지: " + attackPower);
            }
            else
            {
                Debug.LogWarning("타겟 플레이어가 연결되지 않았습니다!");
            }
        }
    }
}
