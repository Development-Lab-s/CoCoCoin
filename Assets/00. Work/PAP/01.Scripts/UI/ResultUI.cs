using DG.Tweening;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultText;
    private Vector3 originPos;
    private Vector3 newPos;
    private void Awake()
    {
        originPos = resultText.transform.position + Vector3.right * 1;
        newPos = resultText.transform.position + Vector3.left * 1;
    }
    
    public void Head()
    {
        resultText.SetText("앞면!");
        Sequence seq = DOTween.Sequence();
        resultText.transform.position = originPos;
        resultText.color = new Color(1f, 1f, 0.65f);
        seq.Append(resultText.transform.DOMove(newPos, 0.4f)); 
        seq.Join(resultText.DOFade(0f,0.4f));
        seq.AppendCallback(()=>
        {
            resultText.SetText("");
            resultText.transform.localScale = Vector3.one;
            resultText.color = Color.white;
        });
        seq.Play();
    }

    public void Tail()
    {
        resultText.SetText("뒷면");
        Sequence seq = DOTween.Sequence();
        resultText.transform.position = newPos;
        resultText.color = new Color(0.7f, 0.7f, 0.7f);
        seq.Append(resultText.transform.DOMove(originPos, 0.4f)); 
        seq.Join(resultText.DOFade(0f,0.4f));
        seq.AppendCallback(()=>
        {
            resultText.SetText("");
            resultText.transform.localScale = Vector3.one;
            resultText.color = Color.white;
        });
        seq.Play();
    }
}
