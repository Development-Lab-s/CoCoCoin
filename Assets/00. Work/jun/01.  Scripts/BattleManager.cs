using DG.Tweening;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _00._Work.PAP._01.Scripts.Motions;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
    using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    // 현재 전투의 상태 정의
    public enum State { Start, PlayerTurn, PlayerPlaying, EnemyTurn, Wait, End }
    public State currentState;

    [SerializeField] private Player player;
    
    public Enemy enemy;

    [SerializeField] private InventorySO inventory;

    [SerializeField] private GameObject chipModelPrefab;

    [SerializeField] private Transform chipUI;
    [SerializeField] private InventoryToolTip inventoryToolTipUI;

    public int amountDrawMax;

    [SerializeField] Rigidbody2D coinRigid;
    [SerializeField] Animator handAnimator;
    [SerializeField] Animator coinAnimator;
    [SerializeField] Transform coinTrm;
    [SerializeField] SpriteRenderer coinSprite;

    [SerializeField] CheckChipList chipList;

    [SerializeField] TextMeshProUGUI maxChipText;

    [SerializeField] TextMeshProUGUI drawChipText;

    [SerializeField] FlipCoin flip;

    [SerializeField] private CurrentEnemySetting currentEnemySettiing;

    [SerializeField] private TurnHandMotionHandler turnMotionHandler;

    public List<InventoryItemSO> drawChips = new List<InventoryItemSO>();
    public List<InventoryItemSO> nowChips =  new List<InventoryItemSO>();
    public List<InventoryItemSO> discardChips = new List<InventoryItemSO>();

    private List<GameObject> chipModels = new List<GameObject>();

    private List<InventoryItemSO> chipsOrder = new List<InventoryItemSO>();

    public bool isActive = true;

    public bool isLocked = false;

    public bool canUse = true;

    public int needDiscard;


    public static BattleManager instance;

    private void ChangeNowChips()
    {
        drawChipText.SetText(nowChips.Count.ToString());
    }

    private void Awake()
    {
        instance = this;
        coinSprite.color = Color.clear;
    }


    private void Start()
    {
        enemy.Init(currentEnemySettiing.Data.enemySprite,currentEnemySettiing.Data.Health);
        
        amountDrawMax = GameData.instance.amountDrawMax;
        maxChipText.SetText(amountDrawMax.ToString());
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
        if (GameData.instance.amountDrawMax > nowChips.Count)
        {
            if (drawChips.Count <= 0) ShuffleChips();
            if (drawChips.Count <= 0)
            {
                Debug.Log("이미 모든 카드를 다 뽑았습니다!");
                return targetChip;
            }
            targetChip = drawChips[Random.Range(0, drawChips.Count)];
            drawChips.Remove(targetChip);
            nowChips.Add(targetChip);

            ChangeNowChips();
            GameObject chipModel = Instantiate(chipModelPrefab, chipUI);
            chipModel.GetComponent<ChipDraw>().Init(inventoryToolTipUI, targetChip, chipUI);
            chipModels.Add(chipModel);

        }
        return targetChip;
    }

    public void DiscardChip(InventoryItemSO chip,GameObject chipModel)
    {
        discardChips.Add(chip);
        nowChips.Remove(chip);
        chipModels.Remove(chipModel);
        Destroy(chipModel);
        ChangeNowChips();
    }
    public void PassTurn()
    {
        if (currentState != State.PlayerTurn)
            return;
        currentState = State.Wait;
        TurnMotion();
    }

    async void TurnMotion()
    {
        turnMotionHandler.PlayMotion();
        await Task.Delay(1000);
        CheckBattleStatus();
    }
    private void Update()
    {
        if (chipsOrder.Count > 0 && isActive && currentState == State.PlayerTurn)
        {
            isActive = false;
            foreach (StatusEffect statusEffect in player.statusEffectHandler.nowStatusEffectList)
            {
                statusEffect.OnUse(player, enemy);
            }
            currentState = State.PlayerPlaying;
            InventoryItemSO chip = chipsOrder[0];
            chipsOrder.Remove(chip);
            handAnimator.SetTrigger("Toss");
            flip.chip = chip;
        }
        if (chipsOrder.Count >= 2)
        {
            Time.timeScale = 2f;
        }
        else if (Time.timeScale == 2f)
        {
            Time.timeScale = 1.0f;
        }
}
    public void UseChip(InventoryItemSO chip)
    {
        if (chip.ChipEncounter.type == ChipEncounter.Type.Stop)
        {
            canUse = false;
        }
        chipsOrder.Add(chip);
    }
    public List<InventoryItemSO>[] ReturnChipLists()
    {
        return new List<InventoryItemSO>[] { drawChips, nowChips, discardChips};
    }
    private void StartPlayerTurn()
    {
        currentState = State.PlayerTurn;
        for (int i = 0; i < GameData.instance.amountDrawOnce; i++)
        {
            DrawChip();
        }
        foreach (StatusEffect statusEffect in player.statusEffectHandler.nowStatusEffectList)
        {
            statusEffect.OnStartTurn(player, enemy);
        }
        if (player.statusEffectHandler.nowStatusEffectList.Count > 0)
        {
            foreach (StatusEffect effect in player.statusEffectHandler.nowStatusEffectList)
            {
                player.statusEffectHandler.AddCount(effect, -1);
            }
            player.statusEffectHandler.nowStatusEffectList.RemoveAll(effect => effect.leftTurns <= 0);
        }
    }

    private void CheckBattleStatus()
    {
        StartCoroutine(EnemyTurnRoutine());
    }

    private IEnumerator EnemyTurnRoutine()
    {
        currentState = State.EnemyTurn;

        // 적의 턴이 끝날 때까지 기다림
        yield return StartCoroutine(enemy.DoTurn(player));

        if (GameData.instance.playerCurrentHp <= 0)
        {
            SceneManageHandler.instance.MoveScene(0);
            currentState = State.End;
            Debug.Log("패배...");
        }
        else
        {
            if (!player.statusEffectHandler.nowStatusEffectList.Exists(effect => effect.checkValue == "SaveDefense"))
                player.ClearShield();
            StartPlayerTurn();
        }
    }
}