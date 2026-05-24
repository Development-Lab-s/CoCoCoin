using DG.Tweening;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _00._Work.PAP._01.Scripts;
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

     public InventorySO inventory;

    [SerializeField] private GameObject chipModelPrefab;

    [SerializeField] private Transform chipUI;
    [SerializeField] private InventoryToolTip inventoryToolTipUI;
    [SerializeField] private DrawMotionHandler drawMotionHandler;

    private int _amountDrawMax = 10;
    public int AmountDrawMax
    {
        get
        {
            return _amountDrawMax;
        } 
        set
        {
            _amountDrawMax = value;
            maxChipText.SetText(_amountDrawMax.ToString());
        }
    }

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
    
    [SerializeField] private BellNextTurn bellNextTurn;

    public List<InventoryItemSO> drawChips = new List<InventoryItemSO>();
    public List<InventoryItemSO> nowChips =  new List<InventoryItemSO>();
    public List<InventoryItemSO> discardChips = new List<InventoryItemSO>();

    public List<GameObject> chipModels { get; private set; } = new List<GameObject>();

    private List<InventoryItemSO> chipsOrder = new List<InventoryItemSO>();

    public bool isActive = true;

    public bool isLocked = false;
    
    public bool isReplicated = false;

    public bool canUse = true;

    public int needDiscard;


    public static BattleManager instance;

    public void ChangeNowChips()
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
        enemy.Init(currentEnemySettiing.Data);
        
        AmountDrawMax = GameData.instance.amountDrawMax;
        
        currentState = State.Start;
        foreach (InventoryItemSO item in inventory.inventoryItemList)
        {
            drawChips.Add(item);
        }
        enemy.AttackPower = currentEnemySettiing.Data.damage[Random.Range(0,currentEnemySettiing.Data.damage.Count)];
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
        if (AmountDrawMax > nowChips.Count)
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
        if (nowChips.Count <= 0)
        {
            bellNextTurn.Bright();
        }
    }
    public void PassTurn()
    {
        if (currentState != State.PlayerTurn || currentState == State.Wait || needDiscard > 0)
            return;
        currentState = State.Wait;
        bellNextTurn.Normal();
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
        StatusEffect sevenrepeat =
            player.statusEffectHandler.nowStatusEffectList.Find(effect => effect.checkValue == "SevenMoreChip");
        if (sevenrepeat != null)
        {
            player.statusEffectHandler.nowStatusEffectList.Remove(sevenrepeat);
            sevenrepeat.statusEffectUI.Destroy();
            for (int i = 0; i < 7; i++)
            {
                UseChipAct(chip);
            }
        }
        UseChipAct(chip);
    }

    private void UseChipAct(InventoryItemSO chip)
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
        enemy.AttackPower = currentEnemySettiing.Data.damage[Random.Range(0,currentEnemySettiing.Data.damage.Count)];
        for (int i = 0; i < GameData.instance.amountDrawOnce; i++)
        {
            DrawChip();
        }
        drawMotionHandler.DrawChipMotion();
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

            if (player.statusEffectHandler.nowStatusEffectList.Any(effect =>
                    effect.leftTurns <= 0 && effect.checkValue == "Death"))
                _ = SceneManageHandler.instance.MoveScene(5);
            player.statusEffectHandler.nowStatusEffectList.RemoveAll(effect => effect.leftTurns <= 0);
        }
    }

    private void CheckBattleStatus()
    {
        StartCoroutine(EnemyTurnRoutine());
    }

    public void DestroyChip(InventoryItemSO chip)
    {
        drawChips.Remove(chip);
        inventory.inventoryItemList.Remove(chip);
        ChangeNowChips();
    }

    private IEnumerator EnemyTurnRoutine()
    {
        currentState = State.EnemyTurn;

        // 적의 턴이 끝날 때까지 기다림
        yield return StartCoroutine(enemy.DoTurn(player));

        if (GameData.instance.playerCurrentHp <= 0)
        {
            currentState = State.End;
        }
        else
        {
            if (!player.statusEffectHandler.nowStatusEffectList.Exists(effect => effect.checkValue == "SaveDefense"))
                player.ClearShield();
            StartPlayerTurn();
        }
    }
}