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
    [SerializeField] private Image _image;

    private Vector3 _endPos = new Vector3(-484, 5219, 0);
    void Start()
    {
        _image.color = new Color(1f, 1f, 1f, 0f);
        _Text.color = new Color32(255, 255, 255, 0);
        StartCoroutine(Cutscene());
    }

    private IEnumerator Cutscene()
    {
        _openCloseSound.Play();
        yield return new WaitForSeconds(3f);
        _image.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        _Text.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(2f);
        _transform.DOAnchorPos(_endPos,30f);
    }
}
