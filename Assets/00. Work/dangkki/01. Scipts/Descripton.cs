using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Descripton : MonoBehaviour
{
    TextMeshProUGUI _descriptionPanel_Name;
    TextMeshProUGUI _descriptionPanel_Description;
    Image _descriptionPanel_Sprite;

    public Transform _descriptionPanel;
    public Transform _mouseContainer;
    public InventorySO _inventorySO;
    public ItemManager _itemManager;



    Vector3 _pos;
    private void Awake()
    {
        _descriptionPanel.gameObject.SetActive(false);
        _descriptionPanel_Name = _descriptionPanel.GetChild(0).GetComponent<TextMeshProUGUI>();
        _descriptionPanel_Description = _descriptionPanel.GetChild(1).GetComponent<TextMeshProUGUI>();
        _descriptionPanel_Sprite = _descriptionPanel.GetChild(2).GetComponent<Image>();

    }
    private void FixedUpdate()
    {
        
        _mouseContainer.position = Input.mousePosition;
    }
    public void OnHover()
    {

        _descriptionPanel.gameObject.SetActive(true);
        
    }
    public void OnExit()
    {
        if (_descriptionPanel != null)
        {
            _descriptionPanel.gameObject.SetActive(false);
        }
    }
   

    public void SetDescription(int itemNumber)
    {
        if (_descriptionPanel != null)
        {
            _descriptionPanel_Name.text = _itemManager._sellitem[itemNumber-1].Description;
            _descriptionPanel_Description.text = _itemManager._sellitem[itemNumber-1].Name;
            _descriptionPanel_Sprite.sprite = _itemManager._sellitem[itemNumber-1].Sprite;
        }
        else
        {
            Debug.LogError("ㅗㅗㅗ");
        }
    }


}
