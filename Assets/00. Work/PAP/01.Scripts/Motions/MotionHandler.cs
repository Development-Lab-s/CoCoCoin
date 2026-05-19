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
}
