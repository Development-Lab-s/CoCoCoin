using UnityEngine;

public class TestClear : MonoBehaviour
{
    private void Start()
    {
        InventoryManager.instance.ClearItem();
    }
}
