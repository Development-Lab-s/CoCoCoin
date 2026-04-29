using DG.Tweening;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private string enemyName = "몬스터";
    [SerializeField] private int hp = 50;
    [SerializeField] private TextMeshProUGUI shieldText;
    private int displayHP;
    public int displayShield;
    public int shieldHP = 0;
    public int attackPower = 10;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] EnemyMotionHandler motionHandler;

    private Vector3 originScale;
    private Vector3 newScale;

    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] DamageEncounter damageEncounter;
    private Color shieldTextColor;
    bool enabledSmoothMove = true;
    float t = 0.0f;
    float speed = 2f;
    private void Start()
    {
        displayHP = hp;
        shieldTextColor = shieldText.color;
        originScale = transform.localScale;
        newScale = originScale + new Vector3(-0.025f,0.05f,-0.025f);
        UpdateUI();
    }

    private void Update()
    {
        if (enabledSmoothMove)
        {
            if (t < 1.0f)
            {
                t += Time.deltaTime * speed;
                transform.localScale = Vector3.Lerp(originScale, newScale, t);
            }
            else if (t < 2.0f)
            {
                t += Time.deltaTime * speed;
                transform.localScale = Vector3.Lerp(newScale, originScale, t-1);
            }
            else
            {
                t = 0.0f;
            }
        }
    }


    public int EnemyCurrentHP()
    {
        return hp;
    }

    // 적의 턴 행동
    public IEnumerator DoTurn(Player player)
    {
        yield return motionHandler.PlayMotion("Normal",attackPower);
    }

    public void TakeDamage(int damage)
    {
        damageEncounter.MarkDamageEncounter(gameObject.GetComponent<Enemy>(), damage);
        int dealDamage = damage;
        dealDamage -= shieldHP;
        shieldHP = Mathf.Clamp(-dealDamage, 0, int.MaxValue);
        dealDamage = Mathf.Clamp(dealDamage, 0, int.MaxValue);
        hpText.transform.DOShakeScale(2f, Mathf.Clamp(damage / 50f,0,10));
        hp -= dealDamage;
        // 적의 HP를 Get함수로 확인
        StartCoroutine(DecreaseHPAnimation(damage));
        StartCoroutine(DecreaseShieldAnimation(damage));
    }

    public void GetShield(int shield)
    {
        shieldHP = Mathf.Clamp(shieldHP + shield, 0, int.MaxValue);
        StartCoroutine(IncreaseShieldAnimation(shieldHP));
    }

    private void UpdateUI()
    {
        if (hpText != null)
        {
            hpText.SetText(displayHP.ToString());
        }
        if (displayHP <= 0)
        {
            Debug.Log("승리!");
            BattleManager.instance.currentState = BattleManager.State.End;
            Time.timeScale = 0f;
        }
    }

    private void UpdateShieldUI()
    {
        if (shieldText != null)
        {
            shieldText.SetText($"+{displayShield.ToString()}");
            if (shieldHP > 0)
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
            while (displayHP > hp)
            {
                displayHP -= damage / 1000 + 1;
                UpdateUI();
                yield return new WaitForSeconds(0.6f / damage); // 1초에 20번 업데이트
            }
            hpText.transform.DOKill();
            hpText.transform.DOScale(Vector3.one,0.2f);
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
            yield return new WaitForSeconds(0.6f / damage); // 1초에 20번 업데이트
        }
    }
}
