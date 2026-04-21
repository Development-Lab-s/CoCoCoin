using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Unity.Cinemachine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName = "몬스터";
    [SerializeField] private int hp = 50;
    [SerializeField] private int maxHp = 50;
    [SerializeField] private int attackPower = 10;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private HealthBar healthbar;

    [SerializeField] private CinemachineImpulseSource impulseSource;

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
        impulseSource.GenerateImpulseWithForce(attackPower / 10f);
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
            //hp = hp;
        }
    }
}
