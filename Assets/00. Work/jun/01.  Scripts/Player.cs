using DG.Tweening;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shieldText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Image bloodImage;
    private int displayHP;
    public int displayShield;
    public int shieldHP = 0;
    public ComboSystem combo;
    private Color shieldTextColor;

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
        dealDamage -= shieldHP;
        shieldHP = Mathf.Clamp(-dealDamage, 0,int.MaxValue);
        dealDamage = Mathf.Clamp(dealDamage, 0, int.MaxValue);
        GameData.instance.playerCurrentHp -= dealDamage;
        if (GameData.instance.playerCurrentHp < 0)
        {
            GameData.instance.playerCurrentHp = 0;
        }
        bloodImage.DOKill();
        bloodImage.color = new Color(1,1,1, Mathf.Clamp(damage/100f,0,1));
        bloodImage.DOFade(0f,1f).SetEase(Ease.OutQuad);
        StartCoroutine(DecreaseHPAnimation(damage));
        StartCoroutine(DecreaseShieldAnimation(damage));
        StartCoroutine(ScreenEffect(damage));
    }

    public void GetShield(int shield)
    {
        shieldHP = Mathf.Clamp(shieldHP + shield, 0, int.MaxValue);
        StartCoroutine(IncreaseShieldAnimation(shieldHP));
    }

    public void DiscardShield(int shield)
    {
        shieldHP = Mathf.Clamp(shieldHP - shield, 0, int.MaxValue);
        StartCoroutine(DecreaseShieldAnimation(shieldHP));
    }

    private void UpdateUI()
    {
        if (hpText != null)
        {
            hpText.SetText(displayHP.ToString());

        }
    }

    private void UpdateShieldUI()
    {
        if (shieldText != null)
        {
            shieldText.SetText($"+{displayShield.ToString()}");
            if (displayShield > 0)
            {
                shieldText.DOFade(1f, 1f).SetEase(Ease.OutQuad);
            }
            else
            {
                shieldText.DOFade(0f, 1f).SetEase(Ease.OutQuad);
            }
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

    IEnumerator DecreaseShieldAnimation(int damage)
    {
        // 1씩 감소하는 모션
        while (displayShield > shieldHP)
        {
            displayShield--;
            UpdateShieldUI();
            yield return new WaitForSeconds(0.6f / damage); // 1초에 20번 업데이트
        }
    }

    IEnumerator IncreaseShieldAnimation(int damage)
    {
        while (displayShield < shieldHP)
        {
            displayShield++;
            UpdateShieldUI();
            yield return new WaitForSeconds(0.6f / damage);
        }
    }

    IEnumerator ScreenEffect(int damage)
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(damage/20);
        Time.timeScale = 1f;
    }
}