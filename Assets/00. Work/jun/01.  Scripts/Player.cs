using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private HealthBar healthbar;

    private void Start()
    {
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
        //GameData.instance.playerCurrentHp -= damage;

        if (GameData.instance.playerCurrentHp < 0)
        {
            GameData.instance.playerCurrentHp = 0;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (hpText != null)
        {
            //hpText.text = $"HP: {GameData.playerCurrentHp} / {GameData.playerMaxHp}";
            healthbar.SetHealth(GameData.instance.playerCurrentHp);
            
        }
    }
}