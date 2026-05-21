using System.Collections;
using System.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public RectTransform[] _contentRect;
    public float _symbolHeight = 250f;
    public float _spinSpeed = 3000f;
    public Transform _slot0;
    public Transform _slot1;
    public Transform _slot2;
    SlotMachine1 slotMachine;
    public Button button;
    public CinemachineCamera Camera;
    
    private SlotScreen SlotScreen;

    private void Awake()
    {
        SlotScreen = GetComponent<SlotScreen>();
    }
    public void StartSpin()
    {
        
        if (TicketManager.instance._spins > 0)
        {
            button.enabled = false;
            TicketManager.instance._spins -= 1;
            TicketManager.instance.SetSpinText(true);
            StartCoroutine(Delay());
        }
        else
            Debug.Log("Spinning failed");
    }

    async void SpinSlot(int x)
    {
        int SpinCount = Random.Range(15, 17);
        for (int i = 0; i < SpinCount; i++)
        {
            float targetY = _contentRect[x].anchoredPosition.y - _symbolHeight;
            while (_contentRect[x].anchoredPosition.y > targetY)
            {
                _contentRect[x].anchoredPosition += new Vector2(0, -_spinSpeed * Time.deltaTime);
            }
            _contentRect[x].anchoredPosition = new Vector2(_contentRect[x].anchoredPosition.x, targetY);
            Transform bottomSymbol = _contentRect[x].GetChild(_contentRect[x].childCount - 1);
            bottomSymbol.SetAsFirstSibling();
            _contentRect[x].anchoredPosition += new Vector2(0, _symbolHeight);
        }
    }
    public IEnumerator Delay()
    { 
        for (int i = 0; i < _contentRect.Length; i++)
        {
            StartCoroutine(SpinCoroutine(i));
            yield return new WaitForSecondsRealtime(0.5f);
        } 
    }
   public IEnumerator SpinCoroutine(int x)
    {
        
        int SpinCount = Random.Range(15, 21);
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
        SlotScreen.Shake();
        if (x == _contentRect.Length - 1)
        {
            button.enabled = true;
            yield return new WaitForSecondsRealtime(0.5f);
            SlotCheck.instance.CheckSlot();
            
        }

    }

}
