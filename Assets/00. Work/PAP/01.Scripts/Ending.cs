using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private AudioSource _openCloseSound;
    [SerializeField] private RectTransform _transform;
    [SerializeField] private TextMeshProUGUI _Text;

    private Vector3 _endPos = new Vector3(497.7198f, 5219, 0);
    void Start()
    {
        StartCoroutine(Cutscene());
    }

    private IEnumerator Cutscene()
    {
        _openCloseSound.Play();
        yield return new WaitForSeconds(3f);
        _Text.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(2f);
        _transform.DOAnchorPos(_endPos,30f);
    }
}
