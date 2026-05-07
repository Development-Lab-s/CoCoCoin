using System.Collections;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public RectTransform[] _contentRect;
    public float _symbolHeight = 250f;
    public float _spinSpeed = 3000f;
    [SerializeField] Transform _slot0;
    [SerializeField] Transform _slot1;
    [SerializeField] Transform _slot2;
    SlotMachine1 slotMachine;

    private void Awake()
    {;
    }
    public void StartSpin()
    {
        for (int i = 0; i < _contentRect.Length; i++)
        {
            StartCoroutine(SpinCoroutine(i));
            Delay();
        }

    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
    }
    public IEnumerator SpinCoroutine(int x)
    {
        int SpinCount = Random.Range(15, 17);
        for (int i = 0; i < SpinCount; i++)
        {
            float targetY = _contentRect[x].anchoredPosition.y - _symbolHeight;
            while (_contentRect[x].anchoredPosition.y > targetY)
            {
                _contentRect[x].anchoredPosition += new Vector2(0, -_spinSpeed * Time.deltaTime);
                yield return null;
            }
            _contentRect[x].anchoredPosition = new Vector2(_contentRect[x].anchoredPosition.x, targetY);
            Transform bottomSymbol = _contentRect[x].GetChild(_contentRect[x].childCount - 1);
            bottomSymbol.SetAsFirstSibling();
            _contentRect[x].anchoredPosition += new Vector2(0, _symbolHeight);
        }
    }

}
