using UnityEngine;

public class TestClear : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.inventoryManager.ClearItem();
    }
}
