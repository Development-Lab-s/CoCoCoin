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

    public void AddChip(Chip item, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            items.Add(item);
        }
    }

    public void RemoveChip(Chip item, int amount)
    {
        if (items.Contains(item))
        {
            for (int i = 0; i < amount; i++)
            {
                items.Remove(item);
            }
        }
    }
}
