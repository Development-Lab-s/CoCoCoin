using DG.Tweening;
using System.Collections;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI comboTextUI;
    public int currentCombo = 0;
    private int pastCombo = 0;
    string[] comboText = { "", "코인!", "코코인!!", "코코코인!!!", "울트라 코인!!!!", "슈퍼 울티메이트 코코인!!!!!", "슈퍼 울트라 울티메이트 코코코인!!!!!!","데브 랩!!!!!!!!!!!!!!" };
    int[] comboMultiplier = {1, 1, 2, 3, 5, 8, 13,21,34,55,89,144};
    Vector3 originPos;
    Vector3 targetPos;
    float speed = 1f;
    float t = 0.0f;
    bool enabledSmoothMove = true;

    private void Start()
    {
        originPos = comboTextUI.rectTransform.position;
        targetPos = originPos + new Vector3(0, -10, 0);
    }

    private void Update()
    {
        if (enabledSmoothMove)
        {
            if (t < 1.0f)
            {
                t += Time.deltaTime * speed;

                comboTextUI.rectTransform.position = Vector3.Lerp(originPos, targetPos, t);
            }
            else if (t < 2.0f)
            {
                t += Time.deltaTime * speed;
                comboTextUI.rectTransform.position = Vector3.Lerp(targetPos, originPos, t - 1);
            }
            else
            {
                t = 0.0f;
            }
        }

    }

    public void SetCombo(int addVal)
    {
        speed = 1f + currentCombo * 0.2f;
        currentCombo = Mathf.Clamp(currentCombo + addVal, 0, comboText.Length - 1);
        GetComponent<AudioSource>().Play();
        UpdateUI();
    }

    public void ResetCombo()
    {
        speed = 1f + currentCombo * 0.2f;
        pastCombo = currentCombo;
        if (currentCombo != 0)
        {
            currentCombo = 0;
            ResetUI();
        }
    }

    private void ResetUI()
    {
        enabledSmoothMove = false;
        comboTextUI.rectTransform.DORotate(new Vector3(0, 0, -15), 0.2f);
        comboTextUI.rectTransform.DOMoveY(comboTextUI.rectTransform.position.y - 50, 0.2f).OnComplete(() =>
        {
            comboTextUI.rectTransform.DOMoveX(comboTextUI.rectTransform.anchoredPosition.x + 700, 0.1f).SetEase(Ease.OutQuad);
            comboTextUI.rectTransform.DOMoveY(comboTextUI.rectTransform.anchoredPosition.y + 700, 0.1f).SetEase(Ease.InQuad);
            comboTextUI.rectTransform.DORotate(new Vector3(0, 0, 89), 0.3f);
        });

    }

    private void UpdateUI()
    {
        enabledSmoothMove = true;
        comboTextUI.rectTransform.position = originPos;
        comboTextUI.rectTransform.rotation = Quaternion.identity;
        comboTextUI.color = Color.red;
        comboTextUI.DOColor(Color.green, 0.1f).OnComplete(() => comboTextUI.DOColor(Color.blue, 0.2f).OnComplete(() => comboTextUI.DOColor(new Color(1f, 1f, 0.1f) + new Color(currentCombo * 0.15f, currentCombo * -0.15f, 0), 0.2f)));
        comboTextUI.rectTransform.DORotate(new Vector3(0, 0, -10), 0.1f).OnComplete(() => comboTextUI.rectTransform.DORotate(new Vector3(0, 0, 10), 0.1f).OnComplete(() => comboTextUI.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f).OnComplete(() => comboTextUI.rectTransform.rotation = Quaternion.identity)));
        long fact = ReturnComboCount();
        comboTextUI.SetText($"{comboText[currentCombo]} X{fact}");
    }

    public long ReturnComboCount()
    {
        return comboMultiplier[currentCombo];
    }
}
