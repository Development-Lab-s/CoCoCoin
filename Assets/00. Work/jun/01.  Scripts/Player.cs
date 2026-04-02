using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;

    private void Start()
    {
        UpdateUI();
    }

    // 공격 실행
    public void ExecuteAttack(Enemy target)
    {
        int damage = GameData.playerAttackPower;
        target.TakeDamage(damage);
    }

    // 데미지 입음
    public void TakeDamage(int damage)
    {
        GameData.playerCurrentHp -= damage;

        if (GameData.playerCurrentHp < 0)
        {
            GameData.playerCurrentHp = 0;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (hpText != null)
        {
            hpText.text = $"HP: {GameData.playerCurrentHp} / {GameData.playerMaxHp}";
        }
    }
}