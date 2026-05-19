using DG.Tweening;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private string enemyName = "몬스터";
    [SerializeField] private int hp = 50;
    [SerializeField] private TextMeshProUGUI shieldText;
    [SerializeField] private TextMeshPro damageText;
    [SerializeField] private SpriteRenderer patternImage;
    private int displayHP;
    public int displayShield;
    public int shieldHP = 0;

    public int _attackPower;
    
    public int AttackPower
    {
        get
        {
            return _attackPower;
        }
        set
        {
            int before = _attackPower;
            _attackPower = value; 
            DamageSetting();
        }
    }

    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] EnemyMotionHandler motionHandler;
    [SerializeField] private Transform soundManager;

    private Vector3 originScale;
    private Vector3 newScale;

    private Vector3 originPos;
    private Vector3 newPos;
    private Sprite originSprite;
    public Sprite hitSprite;

    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] DamageEncounter damageEncounter;
    [SerializeField] private SpriteRenderer _sr;
    private Color shieldTextColor;
    bool enabledSmoothMove = true;
    float t = 0.0f;
    float speed = 2f;
    bool isDead = false;
    private EnemyData _enemy;

    public void Init(EnemyData enemyData)
    {
        _enemy = enemyData;
        originSprite = enemyData.enemySprite;
        hitSprite = enemyData.hitSprite;
        originPos = transform.position;
        newPos = transform.position + Vector3.down * 5;
        transform.position = newPos;
        hpText.transform.position += Vector3.down * 5;
        hpText.transform.DOMove(hpText.transform.position + Vector3.up * 5, 0.5f).SetEase(Ease.OutQuad);
        transform.DOMove(originPos, 0.5f).SetEase(Ease.OutQuad);
        _sr.sprite = originSprite;
        this.hp = enemyData.Health;
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
        if (_enemy.readyToAttack != null)
        {
            _sr.sprite = _enemy.readyToAttack;
        }
        damageText.transform.DOScale(Vector3.zero, 0.2f);
        patternImage.transform.DOScale(Vector3.zero, 0.2f);
        transform.DOMoveY(transform.position.y + 1, 0.2f).OnComplete(() =>
        {
            transform.DOMoveY(transform.position.y - 1, 0.2f);
            if (_enemy.Attack != null)
            {
                _sr.sprite = _enemy.Attack;
            }
        });
        damageText.DOColor(new Color(1, 0, 0, 0), 0.2f);
        switch (Random.Range(0, 3))
        {
            case 0:
                soundManager.Find("Growl").GetComponent<AudioSource>().Play();
                break;
            case 1:
                soundManager.Find("Growl (1)").GetComponent<AudioSource>().Play();
                break;
            case 2:
                soundManager.Find("Growl (2)").GetComponent<AudioSource>().Play();
                break;
        }
        yield return motionHandler.PlayMotion("Normal",AttackPower);
        if (_enemy.enemySprite != null)
        {
            _sr.sprite = _enemy.enemySprite;
        }
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
        transform.DOShakePosition(0.35f, 1,100);
        StartCoroutine(ChangeSprite());
        StartCoroutine(DecreaseHPAnimation(damage));
        StartCoroutine(DecreaseShieldAnimation(damage));
    }

    private void DamageSetting()
    {
        damageText.color = new Color(1, 1, 1, 0);
        damageText.transform.localScale = Vector3.zero;
        damageText.transform.DOScale(Vector3.one, 0.2f);
        patternImage.transform.DOScale(Vector3.one, 0.2f);
        damageText.DOColor(Color.red, 0.2f);
        damageText.SetText(AttackPower.ToString());
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
        if (displayHP <= 0 && !isDead)
        {
            isDead = true;
            BattleManager.instance.currentState = BattleManager.State.End;
            if (_enemy.isLast)
            {
                if (SceneManageHandler.instance.CanMove)
                    _ = SceneManageHandler.instance.MoveScene(7);
            }
            else
            {
                if (SceneManageHandler.instance.CanMove)
                    _ = SceneManageHandler.instance.MoveScene(4);
            }
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

    IEnumerator ChangeSprite()
    {
        _sr.sprite = hitSprite;
        yield return new WaitForSeconds(0.4f);
        _sr.sprite = originSprite;
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
