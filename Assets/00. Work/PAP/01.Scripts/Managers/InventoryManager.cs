using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    
    
    private void Awake()
    {
        instance = this;
    }

    
}
