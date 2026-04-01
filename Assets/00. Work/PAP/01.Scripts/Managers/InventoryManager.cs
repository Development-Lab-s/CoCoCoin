using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    static public InventoryManager instance;

    public List<Chip> items;

    private void Awake()
    {
        if (instance == null)
        {
            instance = new InventoryManager();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
