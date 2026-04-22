using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class EnemyTest : MonoBehaviour
{
    [SerializeField] private EnemySoList enemySoList;
    private string enemyName;
    private int hp;
    private int maxHp;
    private int attackPower;
    private Sprite enemySplite;
    private EnemySO nowEnemyData;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private HealthBar healthbar;

    public int EnemyCurrentHP()
    {
        return hp;
    }

    private void Awake()
    {
        nowEnemyData = enemySoList.PopEnemyData();
        attackPower = nowEnemyData.attackPower;
        maxHp = nowEnemyData.maxHp;
        enemyName = nowEnemyData.enemyName;
        enemySplite = nowEnemyData.sprite;
    }

    private void Start()
    {
        UpdateUI();
    }

    // 적의 턴 행동
    public IEnumerator DoTurn(Player player)
    {
        yield return new WaitForSeconds(1.0f);
        //player.TakeDamage(enemyData.attackPower);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (hpText != null)
        {
            //hpText.text = $"HP: {hp} / {maxHp}";
            healthbar.SetHealth(hp);
        }
    }
}
