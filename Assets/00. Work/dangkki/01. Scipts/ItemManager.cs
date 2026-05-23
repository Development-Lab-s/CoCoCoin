using System.Collections.Generic;
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
    public InventorySO _healthList;
    public InventorySO _inventory;
    public Transform[] _itemList;
    public Transform _healthBox;
    public Descripton _descripton;
    public InventoryItemSO[] _sellitem;
    
    private Image[] _itemList_Sprite;
    private Animator[] _itemList_Animation;
    private TextMeshProUGUI[] _itemList_Price;
    private Image[] _itemList_SoldOut;
    private SpriteLibrary[] _itemList_Spin;
    private EventTrigger[] _itemList_EventTrigger;
    
    public InventoryItemSO _healthChip = null;
    [SerializeField] private AudioSource sfx;
    
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
        _isSold = new bool[_itemList.Length + 1];
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
        SetHealth();
    }
    
    public void SetItem()
    {
        
        List<InventoryItemSO> Common = new List<InventoryItemSO>();
        List<InventoryItemSO> Rare = new List<InventoryItemSO>();
        List<InventoryItemSO> Legendary = new List<InventoryItemSO>();
        foreach (InventoryItemSO item in _chipList.inventoryItemList )
        {
            if (item.rarity == InventoryItemSO.Rarity.Common)
                 Common.Add(item);
            else if (item.rarity == InventoryItemSO.Rarity.Rare)
                Rare.Add(item);
            else if (item.rarity == InventoryItemSO.Rarity.Legendary)
                Legendary.Add(item);
        }
        for (int i = 0; i < _itemList.Length; i++)
        {
            int randomNum = Random.Range(1, 11);
            InventoryItemSO ChosenChip = null;
            if (randomNum <= 5) {
                int Rand = Random.RandomRange(0, Common.Count);
                ChosenChip = Common[Rand];
                Common.RemoveAt(Rand);
            }
            else if (randomNum > 5 && randomNum <= 9) {
                int Rand = Random.RandomRange(0, Rare.Count);
                ChosenChip = Rare[Rand];
                Rare.RemoveAt(Rand);
            }
            else {
                int Rand = Random.RandomRange(0, Legendary.Count);
                ChosenChip = Legendary[Rand];
                Legendary.RemoveAt(Rand);
            }
            _itemList_Sprite[i].sprite = ChosenChip.Sprite;
            _itemList_Spin[i].spriteLibraryAsset = ChosenChip.spriteLibrary;
            //_itemList_Animation[i].runtimeAnimatorController = _chipList.inventoryItemList[randomNum].SelectSprite;
            if(ChosenChip.rarity == InventoryItemSO.Rarity.Common) {
                _itemList_Price[i].text = "3$";
                _itemList_Price[i].color = Color.white;
            }
            else if(ChosenChip.rarity == InventoryItemSO.Rarity.Rare) {
                _itemList_Price[i].text = "5$";
                _itemList_Price[i].color = Color.cyan;
            }
            else if(ChosenChip.rarity == InventoryItemSO.Rarity.Legendary) {
                _itemList_Price[i].text = "10$";
                _itemList_Price[i].color = Color.yellow;
            }
            //_itemList_Price[i].text = _chipList.ShopItemList[randomNum].Description;
            _sellitem[i] = ChosenChip;
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
                _ticketManager.UseTicket(3);
                
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
                _ticketManager.UseTicket(5);
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
                _ticketManager.UseTicket(10);
               // _inventory.inventoryItemList.Add(_sellitem[itemNumber - 1]);
            }
            else
            {
                Debug.Log("현제 티켓 : " + _ticketManager._ticket + " 티켓이 부족합니다.");
                return;
            }
                
        }
        sfx.Play();
        _inventory.inventoryItemList.Add(_sellitem[itemNumber - 1]);
        inventoryUI.ScrollView();
        Debug.Log(_sellitem[itemNumber - 1].Name + "구매완료");
        _itemList_SoldOut[itemNumber - 1].enabled = true;
        _itemList_Sprite[itemNumber - 1].color = Color.gray;
        _itemList_Price[itemNumber - 1].text = "Sold Out";
        _isSold[itemNumber - 1] = true;
    }

    public void SetHealth()
    {
            _healthBox.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
            int randomNum = Random.Range(0, 10);
            if (randomNum <= 5)
            {
                _healthChip = _healthList.inventoryItemList[0];
                _healthBox.GetChild(1).GetComponent<TextMeshProUGUI>().text = "5$";
                _healthBox.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.white;
            }
            else if (randomNum > 5 && randomNum <= 9)
            {
                _healthChip = _healthList.inventoryItemList[1];
                _healthBox.GetChild(1).GetComponent<TextMeshProUGUI>().text = "10$";
                _healthBox.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.green;
            }
            else
            {
                _healthChip = _healthList.inventoryItemList[2];
                _healthBox.GetChild(1).GetComponent<TextMeshProUGUI>().text = "25$";
                _healthBox.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.yellow;
            }
            _healthBox.GetChild(0).GetComponent<Image>().sprite = _healthChip.Sprite;
            _healthBox.GetChild(0).GetComponent<Image>().color = Color.white;

        
    }
    public void BuyHealth()
    {
        if (_isSold[5] == true)
        {
            Debug.Log("이미 구매한 아이템입니다.");
            return;
        }
        if (_healthChip.rarity == InventoryItemSO.Rarity.Common)
        {
            if (_ticketManager._ticket >= 5)
            {
                _ticketManager.UseTicket(5);
                GameData.instance.playerCurrentHp += 25;
            }
            else
            {
                Debug.Log("현제 티켓 : " + _ticketManager._ticket + " 티켓이 부족합니다.");
                return;
            }

        }
        else if (_healthChip.rarity == InventoryItemSO.Rarity.Rare)
        {
            if (_ticketManager._ticket >= 10)
            {
                _ticketManager.UseTicket(10);
                GameData.instance.playerCurrentHp += 50;
            }
            else
            {
                Debug.Log("현제 티켓 : " + _ticketManager._ticket + " 티켓이 부족합니다.");
                return;
            }
        }
        else if (_healthChip.rarity == InventoryItemSO.Rarity.Legendary)
        {
            if (_ticketManager._ticket >= 25)
            {
                _ticketManager.UseTicket(25);
                GameData.instance.playerCurrentHp += 100;
            }
            else
            {
                Debug.Log("현제 티켓 : " + _ticketManager._ticket + " 티켓이 부족합니다.");
                return;
            }
                
        }
        inventoryUI.ScrollView();
        GameData.instance.playerCurrentHp = Mathf.Clamp(GameData.instance.playerCurrentHp, 0, 100);
        Debug.Log("체력 구매완료");
        _healthBox.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
        _healthBox.GetChild(0).GetComponent<Image>().color = Color.gray;
        _healthBox.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Sold Out";
        _isSold[5] = true;
    }
    
}