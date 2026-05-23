using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAnotherScene : MonoBehaviour
{
    [SerializeField] private List<InventoryItemSO> itemSettings;
    [SerializeField] private InventorySO inventory;
    public void Change()
    {
        Set();
        _ = SceneManageHandler.instance.MoveScene(1);
    }
    
    public void TutoChange()
    {
        Set();
        _ = SceneManageHandler.instance.MoveScene(6);
    }

    private void Set()
    {
        GameData.instance.playerCurrentHp = 100;
        MapManager.currentFloor = 1;
        inventory.inventoryItemList.Clear();
        foreach (InventoryItemSO item in itemSettings)
        {
            inventory.inventoryItemList.Add(item);
        }
    }
}
