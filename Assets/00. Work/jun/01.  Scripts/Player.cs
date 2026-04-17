using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private HealthBar healthbar;
    [SerializeField] private Image bloodImage;

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
        GameData.instance.playerCurrentHp -= damage;

        if (GameData.instance.playerCurrentHp < 0)
        {
            GameData.instance.playerCurrentHp = 0;
        }
        bloodImage.color = new Color(1,1,1, Mathf.Clamp(damage/100f,0,1));
        bloodImage.DOFade(0f,1f).SetEase(Ease.OutQuad);
        UpdateUI(); 
    }

    public void UpdateUI()
    {
        if (hpText != null)
        {
            hpText.SetText(GameData.instance.playerCurrentHp.ToString());

        }
    }
}