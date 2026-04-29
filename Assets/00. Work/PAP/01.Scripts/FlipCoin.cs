using DG.Tweening;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using static UnityEngine.Rendering.ProbeAdjustmentVolume;

public class FlipCoin : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] CinemachineCamera cineCamera;
    [SerializeField] CinemachineImpulseSource shaker;
    [SerializeField] Transform basicTrm;

    [Header("Coin")]
    [SerializeField] Transform coinTrm;
    [SerializeField] SpriteRenderer coinSprite;
    [SerializeField] ParticleSystem coinParticle;
    [SerializeField] Animator coinAnimator;

    [Header("Others")]
    [SerializeField] Enemy enemy;
    [SerializeField] Player player;
    [SerializeField] MotionHandler motion;
    [SerializeField] ComboSystem comboSystem;
    [SerializeField] ResultUI resultUI;

    Transform handTrm;
    Animator handAnimator;
    Vector3 originPos;
    Vector3 handOriginPos;
    Vector3 handNewPos;
    float t = 0.0f;

    float speed = 0.5f;

    bool smoothHandMove = true;

    public InventoryItemSO chip;

    private void Awake()
    {
        handTrm = transform;
        handAnimator = GetComponent<Animator>();
        originPos = coinTrm.position;
        handOriginPos = handTrm.position;
        handNewPos = handOriginPos + new Vector3(0, -0.25f, 0);
    }

    private void Update()
    {
        if (smoothHandMove)
        {
            if (t < 1.0f)
            {
                t += Time.deltaTime * speed;

                handTrm.position = Vector3.Lerp(handOriginPos, handNewPos, t);
            }
            else if (t < 2.0f)
            {
                t += Time.deltaTime * speed;
                handTrm.position = Vector3.Lerp(handNewPos, handOriginPos, t - 1);
            }
            else
            {
                t = 0.0f;
            }
        }
    }


    public void TossCoin()
    {
        shaker.GenerateImpulseWithForce(0.5f);

        coinSprite.DOColor(Color.white, 0.1f);
        coinParticle.transform.position = coinTrm.position;
        coinParticle.Stop();
        coinParticle.Play();
        coinAnimator.SetBool("isFlip", true);
        coinTrm.DOMove(coinTrm.position + Vector3.up * 5, 0.5f).SetEase(Ease.OutQuad).OnComplete(JumpEnded);
        cineCamera.Follow = coinTrm;
        void JumpEnded()
        {
            handAnimator.SetTrigger("Grab");
            coinTrm.DOMove(coinTrm.position + Vector3.down * 5, 0.4f).SetEase(Ease.InQuad).OnComplete(()=> StartCoroutine(ShowChip()));
        }

        IEnumerator ShowChip()
        {
            shaker.GenerateImpulse();
            cineCamera.Follow = basicTrm;
            coinSprite.color = Color.clear;
            coinTrm.position = originPos;
            coinAnimator.SetBool("isFlip", false);
            yield return new WaitForSeconds(0.2f);
            handAnimator.SetTrigger("Turn");
            bool isHead = chip.ChipEncounter.FlipCoin(player, enemy);
            yield return new WaitForSeconds(0.4f);
            if (isHead)
            {
                resultUI.Head();
            }
            else
            {
                resultUI.Tail();
            }
            yield return new WaitForSeconds(0.6f);
            SkillChipUse(isHead);
        }

        void SkillChipUse(bool isHead)
        {
            motion.PlayMotion(isHead, player, enemy, chip.ChipEncounter, chip.ChipEncounter.headChipMotion, chip.ChipEncounter.tailChipMotion);
            if (isHead)
            {
                comboSystem.SetCombo(1);
            }
            else
            {
                if (player.statusEffectHandler.nowStatusEffectList.Exists(effect => effect.checkValue == "SaveCombo"))
                {
                    player.statusEffectHandler.AddCount(player.statusEffectHandler.nowStatusEffectList.Find(effect => effect.checkValue == "SaveDefense"),-77);
                }
                else
                {
                    comboSystem.ResetCombo();
                }
            }
        }
    }
}
