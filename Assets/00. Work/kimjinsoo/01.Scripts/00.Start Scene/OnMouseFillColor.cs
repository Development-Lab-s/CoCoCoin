using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseFillColor : MonoBehaviour, IPointerEnterHandler ,IPointerExitHandler 
{
    [SerializeField]private Slider slider;
    private float chargingTime ;

    private bool mouseEntered = false;
    private bool mouseExited = false;

    private void Awake()
    {
        chargingTime = Time.deltaTime;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        mouseEntered = true;
        mouseExited = false;
        Debug.Log("마우스 올려져있음");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseEntered = false;
        mouseExited= true;
        Debug.Log("마우스 나감");
    }

    private void Update()
    {
        if(mouseEntered == true)
        {
            slider.value += chargingTime;
            
        }
        if (mouseExited == true)
        {
            slider.value -= chargingTime;
        }

            

    }
}

