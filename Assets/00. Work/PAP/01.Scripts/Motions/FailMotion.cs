using System.Net.Mime;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FailMotion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private GameObject failButton;
    void Start()
    {
        failButton.SetActive(false);
        textUI.transform.DOMoveY(540,3f).OnComplete(() =>
        {
            failButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            failButton.SetActive(true);
            failButton.GetComponent<Image>().DOFade(1f, 0.5f);
        });
    }
    
}
