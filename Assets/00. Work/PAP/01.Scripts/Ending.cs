using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private AudioSource _openCloseSound;
    [SerializeField] private RectTransform _transform;
    [SerializeField] private TextMeshProUGUI _Text;
    [SerializeField] private Image illust;

    private Vector3 _endPos = new Vector3(-506, 5219, 0);
    void Start()
    {
        StartCoroutine(Cutscene());
        _Text.color = new Color(1,1,1,0);
        illust.color = new Color(1, 1, 1, 0);
    }

    private IEnumerator Cutscene()
    {
        _openCloseSound.Play();
        yield return new WaitForSeconds(3f);
        illust.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(1f);
        _Text.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(2f);
        _transform.DOAnchorPos(_endPos,30f);
    }
}
