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
        damageEncounterText.fontSize = 100;
        damageEncounterTextUI.transform.position = enemy.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        damageEncounterTextUI.transform.DOMove(damageEncounterTextUI.transform.position + new Vector3(0, 2, 0), 0.7f);
        damageEncounterText.DOFade(0f, 0.7f).SetEase(Ease.InQuad).OnComplete(() => Destroy(damageEncounterTextUI));
    }
}
