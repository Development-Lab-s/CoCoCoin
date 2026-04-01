using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public InventoryManager inventoryManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }




}
