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
        Debug.Log(TicketManager.instance._spins);
        if (TicketManager.instance._spins > 0)
        {
            Debug.Log(TicketManager.instance._spins);
            TicketManager.instance._spins -= 1;
            StartCoroutine(SpinCoroutine());
        }
        else
        {
            Debug.Log("Spinning failed");
        }
        
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
            bottomSymbol.SetAsFirstSibling();
            _contentRect.anchoredPosition += new Vector2(0, _symbolHeight);
            _symbolName = bottomSymbol.name;
        }
      //_slotCheck.CheckSlot();
    }

}
