using DG.Tweening;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shieldText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Image bloodImage;
    [SerializeField] private Image clawImage;
    [SerializeField] private Animator animator;
    public StatusEffectHandler statusEffectHandler;
    private int displayHP;
    public int displayShield;
    public int shieldHP = 0;
    public ComboSystem combo;
    private Color shieldTextColor;
    bool shieldActive = true;

    private void Start()
    {
        displayHP = GameData.instance.playerCurrentHp;
        shieldTextColor = shieldText.color;
        UpdateUI();
    }

    // 공격 실행
    //public void ExecuteAttack(Enemy target)
    //{
    //    int damage = GameData.instance.playerCurrentHp;
    //    target.TakeDamage(damage);
    //}

    // 데미지 입음
    public void TakeDamage(int damage)
    {
        int dealDamage = damage;
        if (statusEffectHandler.nowStatusEffectList.Exists(effect => effect.checkValue == "DamageSeven"))
            dealDamage *= 7;
        dealDamage -= shieldHP;
        shieldHP = Mathf.Clamp(-dealDamage, 0,int.MaxValue);
        dealDamage = Mathf.Clamp(dealDamage, 0, int.MaxValue);
        if (statusEffectHandler.nowStatusEffectList.Exists(effect => effect.checkValue == "ReturnDefense"))
            BattleManager.instance.enemy.TakeDamage(damage - dealDamage);
        GameData.instance.playerCurrentHp = Mathf.Max(GameData.instance.playerCurrentHp-dealDamage,0);

        if (shieldHP > 0)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    animator.SetTrigger("Parry");
                    break;
                case 1:
                    animator.SetTrigger("Deflect");
                    break;
            }
        }
        clawImage.DOKill();
        clawImage.rectTransform.rotation = Quaternion.Euler(0, Random.Range(0, 2) == 0 ? 0 : 180, 0);
        clawImage.DOFade(0.6f,0.3f).SetEase(Ease.OutQuad).OnComplete(() => clawImage.DOFade(0f,0.7f));
        bloodImage.DOKill();
        bloodImage.color = new Color(1,1,1, Mathf.Clamp(damage/100f,0,1));
        bloodImage.DOFade(0f,1f).SetEase(Ease.OutQuad);
        StartCoroutine(DecreaseHPAnimation(dealDamage));
        StartCoroutine(ShieldAnimation(dealDamage));
        if (GameData.instance.playerCurrentHp == 0)
        {
            _ = SceneManageHandler.instance.MoveScene(5);
        }
    }

    private Coroutine shieldTextAnimation;
    public void GetShield(int shield)
    {
        
        int target = shield;
        foreach (StatusEffect statusEffect in statusEffectHandler.nowStatusEffectList)
        {
            statusEffect.OnDefense(target, out target);
            
        }
        target *= (int)combo.ReturnComboCount();
        shieldHP += target;
        StartCoroutine(ShieldAnimation(target));
        
    }

    public void DiscardShield(int shield)
    {
        shieldHP = Mathf.Max(shieldHP-shield,0);
        StartCoroutine(ShieldAnimation(shield));
    }

    public void ClearShield()
    {
        shieldHP = 0;
        displayShield = 0;
        UpdateShieldUI();
    }

    public void UpdateUI()
    {
        if (hpText != null)
        {
            hpText.SetText(displayHP.ToString());

        }
    }

    private void UpdateShieldUI()
    {
        shieldText.SetText($"+{displayShield.ToString()}");
        if (displayShield > 0 && shieldActive)
        {
            shieldActive = false;
            shieldText.DOFade(1f, 1f).SetEase(Ease.OutQuad);
        }
        else if (displayShield == 0 && shieldActive == false)
        {
            shieldActive = true;
            shieldText.DOFade(0f, 1f).SetEase(Ease.OutQuad);
        }
    }

    bool isDecreaseHp = false;
    IEnumerator DecreaseHPAnimation(int damage)
    {
        if (!isDecreaseHp)
        {
            isDecreaseHp = true;
            // 1씩 감소하는 모션
            while (displayHP > GameData.instance.playerCurrentHp)
            {
                displayHP--;
                UpdateUI();
                yield return new WaitForSeconds(0.6f / damage); // 1초에 20번 업데이트
            }
            isDecreaseHp = false;
        }
    }

    IEnumerator ShieldAnimation(int damage)
    {
        while (displayShield != shieldHP)
        {
            if (displayShield > shieldHP)
            {
                displayShield--;
            }
            else
            {
                displayShield++;
            }
            UpdateShieldUI();
            yield return new WaitForSeconds(0.6f / damage);
        }
    }


}