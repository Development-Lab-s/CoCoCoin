using System;
using System.Collections;
using _00._Work.jun.Star;
using Unity.Cinemachine;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.EventSystems.EventTrigger;
using Random = UnityEngine.Random;

public class MotionHandler : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] Animator animator;
    [SerializeField] GameObject rightHand;
    [SerializeField] LeftMotionHandler leftMotionHandler;
    [SerializeField] private Transform SoundManager;
    [SerializeField] private SpawnStar spawnStar;
    private AudioSource _hitSFX;
    private AudioSource _tableSFX;

    private void Start()
    {
        _hitSFX = SoundManager.Find("Hit").GetComponent<AudioSource>();
        _tableSFX = SoundManager.Find("Table").GetComponent<AudioSource>();
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void PlayMotion(bool isHead,Player player, Enemy enemy,ChipEncounter chip,int headChipMotion,int tailChipMotion)
    {
        gameObject.SetActive(true);
        rightHand.SetActive(false);
        switch (isHead ? headChipMotion : tailChipMotion)
        {
            case -10:
                StartCoroutine(ShotGunMotion(player, enemy, chip, isHead));
                break;
            case -1:
                StartCoroutine(LeftHandTurnMotion(player, enemy, chip, isHead));
                break;
            case 0:
                StartCoroutine(NormalPunchMotion(player, enemy, chip,isHead));
                break;
            case 1:
                StartCoroutine(DefenseMotion(player, enemy, chip,isHead));
                break;
            case 100:
                StartCoroutine(JackpotMotion(player, enemy, chip,isHead));
                break;
            case 101:
                StartCoroutine(JackpotMotionFail(player, enemy, chip,isHead));
                break;
            case 102:
                StartCoroutine(BbangReplicated(player, enemy, chip,isHead));
                break;
            case 103:
                StartCoroutine(Fingersnap(player, enemy, chip,isHead));
                break;
            case 104:
                StartCoroutine(FingersnapFail(player, enemy, chip,isHead));
                break;
            case 105:
                StartCoroutine(HandamAI(player, enemy, chip,isHead));
                break;
            case 106:
                StartCoroutine(HandamAIFail(player, enemy, chip,isHead));
                break;
            case 107:
                StartCoroutine(Pat(player, enemy, chip,isHead));
                break;
        }
    }

    private void ChipAbility(Player player, Enemy enemy, ChipEncounter chip, bool isHead)
    {
        if (isHead)
        {
            chip.HeadChip(player, enemy);
        }
        else
        {
            chip.TailChip(player, enemy);
        }
    }

    private void SetEnable(ChipEncounter chip)
    {
        rightHand.SetActive(true);
        gameObject.SetActive(false);
        BattleManager.instance.isActive = true;
        BattleManager.instance.currentState = BattleManager.State.PlayerTurn;
        if (chip.type == ChipEncounter.Type.Stop)
        {
            BattleManager.instance.canUse = true;
        }
    }

    private IEnumerator LeftHandTurnMotion(Player player, Enemy enemy, ChipEncounter chip, bool isHead)
    {
        ChipAbility(player, enemy, chip, isHead);
        if (BattleManager.instance.needDiscard > 0)
        {
            leftMotionHandler.PlayMotion(0);
        }
        yield return null;
        SetEnable(chip);
    }
    private IEnumerator NormalPunchMotion(Player player, Enemy enemy,ChipEncounter chip,bool isHead)
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                animator.SetTrigger("Punch");
                break;
            case 1:
                animator.SetTrigger("Punch2");
                break;
        }
        yield return new WaitForSeconds(0.5f);
        spawnStar.Spawn();
        impulseSource.GenerateImpulseWithVelocity(new Vector3(0.2f, 0, 0));
        ChipAbility(player, enemy, chip, isHead);
        _hitSFX.Play();
        yield return new WaitForSeconds(0.5f);
        SetEnable(chip);

    }
    private IEnumerator DefenseMotion(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("GetBuff");
        yield return new WaitForSeconds(0.5f);
        ChipAbility(player, enemy, chip, isHead);
        yield return new WaitForSeconds(0.5f);
        SetEnable(chip);
    }
    
    private IEnumerator ShotGunMotion(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("ShotGun");
        yield return new WaitForSeconds(0.4f);
        impulseSource.GenerateImpulseWithVelocity(new Vector3(0.2f, 0, 0));
        ChipAbility(player, enemy, chip, isHead);
        _tableSFX.Play();
        yield return new WaitForSeconds(0.3f);
        SetEnable(chip);

    }

    private IEnumerator ShotgunMotionNone()
    {
        animator.SetTrigger("ShotGun");
        yield return new WaitForSeconds(0.4f);
        impulseSource.GenerateImpulseWithVelocity(new Vector3(0.2f, 0, 0));
        _tableSFX.Play();
        yield return new WaitForSeconds(0.3f);
    }
    private IEnumerator JackpotMotion(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("67");
        yield return new WaitForSeconds(0.5f);
        ChipAbility(player, enemy, chip, isHead);
        yield return new WaitForSeconds(0.5f);
        SetEnable(chip);
    }
    
    private IEnumerator JackpotMotionFail(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("67");
        yield return new WaitForSeconds(0.5f);
        ChipAbility(player, enemy, chip, isHead);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(ShotgunMotionNone());
        SetEnable(chip);
    }

    private IEnumerator BbangReplicated(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("Bbang");
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(0.5f);
        SetEnable(chip);
        yield return StartCoroutine(LeftHandTurnMotion(player, enemy, chip, isHead));
    }
    
    private IEnumerator Fingersnap(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("Fingersnap");
        yield return new WaitForSeconds(0.5f);
        ChipAbility(player, enemy, chip, isHead);
        yield return new WaitForSeconds(0.5f);
        SetEnable(chip);
    }
    
    private IEnumerator FingersnapFail(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("Fingersnap");
        yield return new WaitForSeconds(0.5f);
        ChipAbility(player, enemy, chip, isHead);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(ShotgunMotionNone());
        SetEnable(chip);
    }
    
    private IEnumerator HandamAI(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("HandamAi");
        yield return new WaitForSeconds(1f);
        ChipAbility(player, enemy, chip, isHead);
        yield return new WaitForSeconds(1f);
        SetEnable(chip);
    }
    
    private IEnumerator HandamAIFail(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("HandamAi");
        yield return new WaitForSeconds(1f);
        ChipAbility(player, enemy, chip, isHead);
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(ShotgunMotionNone());
        SetEnable(chip);
    }
    
    private IEnumerator Pat(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        animator.SetTrigger("Pat");
        yield return new WaitForSeconds(0.5f);
        ChipAbility(player, enemy, chip, isHead);
        yield return new WaitForSeconds(0.5f);
        SetEnable(chip);
    }
}
