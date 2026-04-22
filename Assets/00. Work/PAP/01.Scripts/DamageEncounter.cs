using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamageEncounter : MonoBehaviour
{
    [SerializeField] GameObject damageEncounterTextUIPrefab;
    

    public void MarkDamageEncounter(Enemy enemy, int damage)
    {
        GameObject damageEncounterTextUI = Instantiate(damageEncounterTextUIPrefab, transform);
        TextMeshProUGUI damageEncounterText = damageEncounterTextUI.GetComponent<TextMeshProUGUI>();
        damageEncounterText.SetText(damage.ToString());
        damageEncounterText.fontSize = Mathf.Clamp(damage * 5, 50, 300);
        damageEncounterTextUI.transform.localScale = Vector3.zero;
        damageEncounterTextUI.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InQuad);
        damageEncounterText.DOFade(0f, 0.7f).SetEase(Ease.InQuad).OnComplete(() => Destroy(damageEncounterTextUI));
        damageEncounterTextUI.transform.position = enemy.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f),0);
    }
}
