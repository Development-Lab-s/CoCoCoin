using DG.Tweening;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    
    [SerializeField] private Enemy enemy;

    [SerializeField] private InventorySO inventory;

    [SerializeField] private GameObject chipModelPrerfab;

    [SerializeField] private Transform chipUI;
    [SerializeField] private InventoryToolTip inventoryToolTipUI;

    public int amountDrawMax;

    [SerializeField] Rigidbody2D coinRigid;
    [SerializeField] Animator handAnimator;
    [SerializeField] Animator coinAnimator;
    [SerializeField] Transform coinTrm;
    [SerializeField] ParticleSystem coinParticle;
    [SerializeField] SpriteRenderer coinSprite;
    [SerializeField] Transform handTrm;
    [SerializeField] SpriteRenderer handSprite;

    [SerializeField] CinemachineImpulseSource shaker;

    [SerializeField] CinemachineCamera cineCamera;

    [SerializeField] CheckChipList chipList;

    [SerializeField] ComboSystem comboSystem;

    [SerializeField] TextMeshProUGUI maxChipText;

    [SerializeField] TextMeshProUGUI drawChipText;

    Vector3 originPos;

    public List<InventoryItemSO> drawChips = new List<InventoryItemSO>();
    public List<InventoryItemSO> nowChips =  new List<InventoryItemSO>();
    public List<InventoryItemSO> discardChips = new List<InventoryItemSO>();

    private List<GameObject> chipModels = new List<GameObject>();

    private List<InventoryItemSO> chipsOrder = new List<InventoryItemSO>();

    public bool isActive = true;

    public static BattleManager instance;

    [SerializeField] MotionHandler motion;

    private void ChangeNowChips()
    {
        drawChipText.SetText(nowChips.Count.ToString());
    }

    private void Awake()
    {
        instance = this;
        originPos = coinTrm.position;
        coinSprite.color = Color.clear;
    }


    private void Start()
    {
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
            targetChip = drawChips[Random.Range(0, drawChips.Count)];
            drawChips.Remove(targetChip);
            nowChips.Add(targetChip);
            ChangeNowChips();
            GameObject chipModel = Instantiate(chipModelPrerfab, chipUI);
            chipModel.GetComponent<ChipDraw>().Init(inventoryToolTipUI, targetChip, chipUI, coinRigid, handAnimator, coinAnimator);
            chipModels.Add(chipModel);

        }
        return targetChip;
    }

    public void DiscardChip(InventoryItemSO chip)
    {
        discardChips.Add(chip);
        nowChips.Remove(chip);
        ChangeNowChips();
    }
    private void PassTurn()
    {
        if (currentState != State.PlayerTurn)
            return;
        currentState = State.Wait;
        CheckBattleStatus();
    }
    private void Update()
    {
        if (chipsOrder.Count > 0 && isActive)
        {
            currentState = State.PlayerPlaying;
            shaker.GenerateImpulseWithForce(0.5f);

            coinSprite.DOColor(Color.white, 0.1f);
            
            isActive = false;
            InventoryItemSO chip = chipsOrder[0];
            chipsOrder.Remove(chip);
            coinParticle.transform.position = coinTrm.position;
            coinParticle.Stop();
            coinParticle.Play();
            handAnimator.SetBool("isFlipping", true);
            coinAnimator.SetBool("isFlip", true);
            coinRigid.DOMove(Vector3.up * 5, 0.5f).SetEase(Ease.OutQuad).OnComplete(JumpEnded);
            cineCamera.Follow = coinTrm;
            void JumpEnded()
            {
                handAnimator.SetTrigger("Grab");
                coinRigid.DOMove(Vector3.down * 5, 0.4f).SetEase(Ease.InQuad);
                handTrm.DORotate(new Vector3(0, 0, -80), 0.3f).OnComplete(() => handTrm.DORotate(new Vector3(0, 0, 30), 0.1f).OnComplete(SkillChipUse));
            }

            void SkillChipUse()
            {
                coinSprite.color = Color.clear;
                coinRigid.position = originPos;
                handAnimator.SetBool("isFlipping", false);
                coinAnimator.SetBool("isFlip", false);
                handTrm.DORotate(Vector3.zero, 0.2f);
                bool isHead = chip.ChipEncounter.FlipCoin(player, enemy,motion);
                if (isHead) 
                {
                    comboSystem.SetCombo(1);
                }
                else
                {
                    comboSystem.ResetCombo();
                }
                shaker.GenerateImpulse();
                cineCamera.Follow = enemy.transform;
            }
        }
        if (chipsOrder.Count >= 3)
        {
            Time.timeScale = 2f;
        }
        else if (Time.timeScale == 2f)
        {
            Time.timeScale = 1.0f;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            PassTurn();
        }
    }
    public void UseChip(InventoryItemSO chip,GameObject chipModel)
    {
        chipsOrder.Add(chip);
        chipModels.Remove(chipModel);
        Destroy(chipModel);
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
            currentState = State.End;
            Debug.Log("패배...");
        }
        else
        {
            player.DiscardShield(player.shieldHP);
            StartPlayerTurn();
        }
    }

    private void RestartBattle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}