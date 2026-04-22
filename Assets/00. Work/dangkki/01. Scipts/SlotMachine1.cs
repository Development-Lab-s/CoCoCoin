using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine1 : MonoBehaviour
{
    public RectTransform _contentRect;
    public float _symbolHeight = 250f;
    public float _spinSpeed = 3000f;
    public string _symbolName;
    public SlotCheck _slotCheck;

    private void Awake()
    {
        _slotCheck = GetComponent<SlotCheck>();
    }
    public void StartSpin()
    {
        StartCoroutine(SpinCoroutine());
    }

    private IEnumerator SpinCoroutine()
    {
        
        int SpinCount = Random.Range(10, 20);
        for (int i = 0; i < SpinCount; i++)
        {
            float targetY = _contentRect.anchoredPosition.y - _symbolHeight;

            while(_contentRect.anchoredPosition.y > targetY)
            {
                _contentRect.anchoredPosition += new Vector2(0, -_spinSpeed * Time.deltaTime);
                yield return null;
            }

            _contentRect.anchoredPosition = new Vector2(_contentRect.anchoredPosition.x, targetY);

            Transform bottomSymbol = _contentRect.GetChild(_contentRect.childCount - 1);

            ////랜덤 지울라면 지울부분
            //int randomIndex = Random.Range(0, allSymbols.Length);
            //bottomSymbol.GetComponent<Image>().sprite = allSymbols[randomIndex];
            //굳이 랜덤 만들지않고그냥 돌리는 횟수를 랜덤으로 돌리면 되잖아 시발

            bottomSymbol.SetAsFirstSibling();

            _contentRect.anchoredPosition += new Vector2(0, _symbolHeight);
            _symbolName = bottomSymbol.name;
        }
      //_slotCheck.CheckSlot(_symbolName);
    }

}
