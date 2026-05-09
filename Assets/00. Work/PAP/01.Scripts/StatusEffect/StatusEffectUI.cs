using DG.Tweening;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class StatusEffectUI : MonoBehaviour
{

    [SerializeField] RectTransform statusEffectUI;
    [SerializeField] TextMeshProUGUI contextText;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] CanvasGroup canvasGroup;

    public void Init()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1f, 0.5f);
    }
    public void UpdateUI(string content,int leftTurns,Color textColor)
    {
        contextText.color = textColor;
        contextText.SetText(content);
        turnText.SetText(leftTurns.ToString() + "턴");
    }

    public void Destroy()
    {
        canvasGroup.DOFade(0f, 0.5f).OnComplete(() => Destroy(gameObject));
    }
}
