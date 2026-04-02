using UnityEngine;

public class LeftHand : MonoBehaviour
{
    [SerializeField]private GameObject opendHand;
    [SerializeField]private SpriteRenderer closedHand;
    private bool isLeftHandActive;


    void OnMouseEnter()
    {
        ToggleLeftHand();
    }
    void OnMouseExit()
    {
        ToggleLeftHand();
    }

    void ToggleLeftHand()
    {
        isLeftHandActive = !isLeftHandActive;
        
        if (closedHand != null)
        {
            closedHand.enabled = !isLeftHandActive;
        }

        if (opendHand != null)
        {
            opendHand.SetActive(isLeftHandActive); 
        }
    }
}
