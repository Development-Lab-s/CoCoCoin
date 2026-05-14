using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OnMouseFillColor : MonoBehaviour, IPointerEnterHandler ,IPointerExitHandler 
{
    [SerializeField]private Slider slider;
    [SerializeField] private float chargingTime ;

    private bool mouseEntered = false;
    private bool mouseExited = false;
    

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        mouseEntered = true;
        mouseExited = false;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseEntered = false;
        mouseExited= true;
        
    }

    private void Update()
    {
        if(mouseEntered == true)
        {
            slider.value += chargingTime * Time.deltaTime;
            
        }
        if (mouseExited == true)
        {
            slider.value -= chargingTime * Time.deltaTime;
        }
    }
}

