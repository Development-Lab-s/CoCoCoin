using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName = "몬스터";
    [SerializeField] private int hp = 50;
    [SerializeField] private int maxHp = 50;
    [SerializeField] private int attackPower = 10;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private HealthBar healthbar;

    public int EnemyCurrentHP()
    {
        return hp;
    }

    private void Start()
    {
        UpdateUI();
    }

    // 적의 턴 행동
    public IEnumerator DoTurn(Player player)
    {
        yield return new WaitForSeconds(1.0f);
        player.TakeDamage(attackPower);
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
