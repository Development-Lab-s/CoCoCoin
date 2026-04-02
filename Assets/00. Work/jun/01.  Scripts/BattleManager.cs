using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    // 현재 전투의 상태 정의
    private enum State { Start, PlayerTurn, EnemyTurn, Wait, End }
    [SerializeField] private State currentState;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    private void Start()
    {
        currentState = State.Start;
        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        currentState = State.PlayerTurn;
    }

    // 버튼 클릭 시 실행
    public void OnAttackButtonClick()
    {
        if (currentState == State.PlayerTurn)
        {
            currentState = State.Wait; // 중복 클릭 방지
            player.ExecuteAttack(enemy);
            CheckBattleStatus();
        }
    }

    private void CheckBattleStatus()
    {
        // 적의 HP를 Get함수로 확인
        if (enemy.EnemyCurrentHP() <= 0)
        {
            currentState = State.End;
            Debug.Log("승리!");
            Invoke("RestartBattle", 2.0f);
        }
        else
        {
            StartCoroutine(EnemyTurnRoutine());
        }
    }

    private IEnumerator EnemyTurnRoutine()
    {
        currentState = State.EnemyTurn;

        // 적의 턴이 끝날 때까지 기다림
        yield return StartCoroutine(enemy.DoTurn(player));

        if (GameData.playerCurrentHp <= 0)
        {
            currentState = State.End;
            Debug.Log("패배...");
        }
        else
        {
            StartPlayerTurn();
        }
    }

    private void RestartBattle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}