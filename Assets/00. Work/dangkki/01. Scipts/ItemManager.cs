using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public TicketManager _ticketManager;
    public ItemBox _itemBox;
    //public ShopItemListSO _chipList;
    
    public InventoryUI inventoryUI;
    
    public InventorySO _chipList;
    public InventorySO _inventory;
    public Transform[] _itemList;
    public Descripton _descripton;
    public InventoryItemSO[] _sellitem;
    
    private Image[] _itemList_Sprite;
    private Animator[] _itemList_Animation;
    private TextMeshProUGUI[] _itemList_Price;
    private Image[] _itemList_SoldOut;
    private SpriteLibrary[] _itemList_Spin;
    private EventTrigger[] _itemList_EventTrigger;
    
    string[] _sellList;
    bool[] _isSold;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        _itemList_Sprite = new Image[_itemList.Length];
        _itemList_Price = new TextMeshProUGUI[_itemList.Length];
        _itemList_SoldOut = new Image[_itemList.Length];
        _itemList_Animation = new Animator[_itemList.Length];
        _itemList_EventTrigger = new EventTrigger[_itemList.Length];
        _itemList_Spin = new SpriteLibrary[_itemList.Length];
        _sellitem = new InventoryItemSO[_itemList.Length];
        _isSold = new bool[_itemList.Length];
        for (int i = 0; i < _itemList.Length; i++)
        {
            _itemList_Sprite[i] = _itemList[i].GetChild(0).GetComponent<Image>();
            _itemList_Price[i] = _itemList[i].GetChild(1).GetComponent<TextMeshProUGUI>();
            _itemList_Animation[i] = _itemList[i].GetChild(0).GetComponent<Animator>();
            _itemList_SoldOut[i] = _itemList[i].GetChild(0).GetChild(0).GetComponent<Image>();
            _itemList_EventTrigger[i] = _itemList[i].GetChild(0).GetComponent<EventTrigger>();
            _itemList_Spin[i] = _itemList[i].GetChild(0).GetComponent<SpriteLibrary>();
            _itemList_SoldOut[i].enabled = false;
            _itemList_Sprite[i].color = Color.white;
        }
    }
    private void Start()
    {
        SetItem();
    }
    public void SetItem()
    {
        for (int i = 0; i < _itemList.Length; i++)
        {
            int randomNum = Random.Range(0, _chipList.inventoryItemList.Count - 1);
            _itemList_Sprite[i].sprite = _chipList.inventoryItemList[randomNum].Sprite;
            _itemList_Spin[i].spriteLibraryAsset = _chipList.inventoryItemList[randomNum].spriteLibrary;
            //_itemList_Animation[i].runtimeAnimatorController = _chipList.inventoryItemList[randomNum].SelectSprite;
            if(_chipList.inventoryItemList[randomNum].rarity == InventoryItemSO.Rarity.Common) _itemList_Price[i].text = "3$";
            else if(_chipList.inventoryItemList[randomNum].rarity == InventoryItemSO.Rarity.Rare) _itemList_Price[i].text = "5$";
            else if(_chipList.inventoryItemList[randomNum].rarity == InventoryItemSO.Rarity.Legendary) _itemList_Price[i].text = "10$";
            //_itemList_Price[i].text = _chipList.ShopItemList[randomNum].Description;
            _sellitem[i] = _chipList.inventoryItemList[randomNum];
            //_descripton.SetDescription(i);
            //}
        }
    }
    public void BuyItem(int itemNumber)
    {
         if (_isSold[itemNumber - 1] == true)
        {
            Debug.Log("이미 구매한 아이템입니다.");
            return;
        }
        if (_sellitem[itemNumber - 1].rarity == InventoryItemSO.Rarity.Common)
        {
            if (_ticketManager._ticket >= 3)
            {
                _ticketManager._ticket -= 3;
                
               // _inventory.inventoryItemList.Add(_sellitem[itemNumber - 1]);
            }
            else
            {
                Debug.Log("현제 티켓 : " + _ticketManager._ticket + " 티켓이 부족합니다.");
                return;
            }

        }
        else if (_sellitem[itemNumber - 1].rarity == InventoryItemSO.Rarity.Rare)
        {
            if (_ticketManager._ticket >= 5)
            {
                _ticketManager._ticket -= 5;
             //   _inventory.inventoryItemList.Add(_sellitem[itemNumber - 1]);
            }
            else
            {
                Debug.Log("현제 티켓 : " + _ticketManager._ticket + " 티켓이 부족합니다.");
                return;
            }
        }
        else if (_sellitem[itemNumber - 1].rarity == InventoryItemSO.Rarity.Legendary)
        {
            if (_ticketManager._ticket >= 10)
            {
                _ticketManager._ticket -= 10;
               // _inventory.inventoryItemList.Add(_sellitem[itemNumber - 1]);
            }
            else
            {
                Debug.Log("현제 티켓 : " + _ticketManager._ticket + " 티켓이 부족합니다.");
                return;
            }
                
        }
        _ticketManager.SetTicketText();
        _inventory.inventoryItemList.Add(_sellitem[itemNumber - 1]);
        inventoryUI.ScrollView();
        Debug.Log(_sellitem[itemNumber - 1].Name + "구매완료");
        _itemList_SoldOut[itemNumber - 1].enabled = true;
        _itemList_Sprite[itemNumber - 1].color = Color.gray;
        _itemList_Price[itemNumber - 1].text = "Sold Out";
        _isSold[itemNumber - 1] = true;
    }
}