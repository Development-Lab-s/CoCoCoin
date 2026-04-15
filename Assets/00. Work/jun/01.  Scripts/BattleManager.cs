    using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class BattleManager : MonoBehaviour
{
    // 현재 전투의 상태 정의
    private enum State { Start, PlayerTurn, EnemyTurn, Wait, End }
    [SerializeField] private State currentState;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    [SerializeField] private InventorySO inventory;

    [SerializeField] private GameObject chipModelPrerfab;

    [SerializeField] private Transform chipUI;
    [SerializeField] private InventoryToolTip inventoryToolTipUI;

    private List<InventoryItemSO> drawChips = new List<InventoryItemSO>();
    private List<InventoryItemSO> nowChips = new List<InventoryItemSO>();
    private List<InventoryItemSO> discardChips = new List<InventoryItemSO>();


    private void Start()
    {
        currentState = State.Start;
        foreach (InventoryItemSO item in inventory.inventoryItemList)
        {
            drawChips.Add(item);
        }
        StartPlayerTurn();
    }

    private void ShuffleChips()
    {
        foreach (InventoryItemSO item in discardChips)
        {
            drawChips.Add(item);
        }
        discardChips.Clear();
    }

    public InventoryItemSO DrawChip()
    {
        InventoryItemSO targetChip = null;
        if (drawChips.Count <= 0) ShuffleChips();
        targetChip = drawChips[Random.Range(0, drawChips.Count)];
        drawChips.Remove(targetChip);
        nowChips.Add(targetChip);
        GameObject chipModel = Instantiate(chipModelPrerfab, chipUI);
        chipModel.GetComponent<ChipDraw>().Init(inventoryToolTipUI, targetChip, chipUI);

        return targetChip;
    }

    private void StartPlayerTurn()
    {

        currentState = State.PlayerTurn;
        for (int i = 0; i < GameData.instance.amountDrawOnce; i++)
        {
            DrawChip();
        }
    }

    // 버튼 클릭 시 실행
    public void OnAttackButtonClick()
    {
        if (currentState == State.PlayerTurn)
        {
            currentState = State.Wait; // 중복 클릭 방지
            //player.ExecuteAttack(enemy);
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

        if (GameData.instance.playerCurrentHp <= 0)
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