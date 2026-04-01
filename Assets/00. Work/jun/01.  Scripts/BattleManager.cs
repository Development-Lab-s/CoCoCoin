using UnityEngine;
using System.Collections;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleManager : MonoBehaviour
{
    public BattleState state;
    public Unit playerUnit; // 플레이어 스크립트 연결용
    public Unit enemyUnit;  // 적 스크립트 연결용

    private void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    private void SetupBattle()
    {
        // 전투 준비가 끝나면 플레이어 턴으로!
        state = BattleState.PLAYERTURN;
        Debug.Log("플레이어 턴");
    }

    // 공격 버튼을 눌렀을 때 실행될 함수
    public void OnAttackButton()
    {   

        if (state != BattleState.PLAYERTURN) return; // 내 턴이 아니면 클릭 안 됨

        // 플레이어가 적을 공격!
        enemyUnit.Damage(playerUnit.power);
        Debug.Log("플레이어가 공격");

        StartCoroutine(enemyUnit.Shake(0.2f, 0.1f));

        // 적의 체력을 체크해서 승리 판정
        if (enemyUnit.hp <= 0)
        {
            state = BattleState.WON;
            Debug.Log("승리");
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn()); // 적의 턴 시작 //star저거는 코르틴 쓸라고 넣은거
        }
    }
    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        // 2. 적이 플레이어를 공격할 때, 플레이어를 흔듭니다!
        StartCoroutine(playerUnit.Shake(0.2f, 0.1f));
    
        Debug.Log("적의 턴");
        yield return new WaitForSeconds(1f); // 1초 대기 

        // 적이 플레이어를 공격
        playerUnit.Damage(enemyUnit.power);
        Debug.Log("적의 공격");

        if (playerUnit.hp <= 0)
        {
            state = BattleState.LOST;
            Debug.Log("패배");
        }
        else
        {
            state = BattleState.PLAYERTURN;
            Debug.Log("다시 플레이어 턴");
        }
    }
}
