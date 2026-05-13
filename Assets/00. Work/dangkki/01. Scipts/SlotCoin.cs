using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotCoin : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private InventorySO inventorySO;
    [SerializeField] private Transform content;       
    [SerializeField] private GameObject itemSlotPrefab;

    public static GameObject beingDraggedCoin;
    Vector3 startPos;
    [SerializeField]Transform onDragParent;
    [SerializeField]Transform startParent;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        beingDraggedCoin= gameObject;
        startPos = transform.position;
        startParent = transform.parent;
        transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        beingDraggedCoin = null;
        if(transform.parent == onDragParent)
        {
            transform.position = startPos;
            transform.SetParent(startParent);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
            beingDraggedCoin.transform.SetParent(transform);
            beingDraggedCoin
                .transform.position = transform.position;
    }

}
