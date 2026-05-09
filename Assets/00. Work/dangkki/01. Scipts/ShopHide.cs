using DG.Tweening;
using UnityEngine;

public class ShopHide : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);

    }
    public void ShowBack()
    {
        gameObject.SetActive(true);
    }
    public void HideBack() { 
        gameObject.SetActive(false);
    }
}
