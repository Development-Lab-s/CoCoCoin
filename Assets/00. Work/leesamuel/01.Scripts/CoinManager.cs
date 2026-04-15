using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int Choose_Number = 0;
    private int Max_Select = 3;
    private string Selct_A = null;
    private string Selct_B = null;
    private string Selct_C = null;
    private GameObject maxui;
    [SerializeField]private float time;
    public InventoryItemSO select_a { get; private set; }
    public InventoryItemSO select_b { get; private set; }
    public InventoryItemSO select_c { get; private set; }
    public bool Coin_Select(InventoryItemSO coinSo)//선택한양이 최대 선택량과 같으면false반환 선택한양이 최대 선택량과 다르면true반환
    {
        if(Choose_Number == Max_Select)
        {
            return false;
        }
        else
        {
            Choose_Number++;
            if (Selct_A == null)
            {
                Selct_A = coinSo.Name;
                select_a = coinSo;
            }
            else if (Selct_B == null)
            {
                Selct_B = coinSo.Name;
                select_b = coinSo;
            }
            else if(Selct_C == null)
            {
                Selct_C = coinSo.Name;
                select_c = coinSo;
            }
            return true;
            
        }    
    }

    private void Start()
    {
        time = 3.0f;
         maxui = GameObject.Find("Max UI");
        maxui.SetActive(false);
    }

    public void Cansle_Select(InventoryItemSO coinSo)//선택 취소시선택한 양을 줄임
    {
        Choose_Number--;
        if (Selct_A == coinSo.Name)
        {
            Selct_A = null;
            select_a = null;
        }
        else if (Selct_B == coinSo.Name)
        {
            Selct_B = null;
            select_b= null;
        }
        else if (Selct_C == coinSo.Name)
        {
            Selct_C = null;
            select_c = null;
        }

        
    }

    private void Update()
    {
        
    }
    public bool SelectCodeinCoin(bool _Select, InventoryItemSO so) 
    {
        if (_Select == true)
        {
            _Select = false;
            Cansle_Select(so);
            //선택한 코인갯수 줄이는 메서드 작동
            return false;
        }
        else
        {
            bool A = Coin_Select(so);//최대 선택갯수가 아니라 선택이 가능하면 true반환 아니면false반환
            if (A == false)
            {
                //UI띄우는 코드 호출 어우 귀찮아 할줄 아는 인원이 해줘
                maxui.SetActive(true);

                return false;
            }
            else
            {
                _Select = true;//선택된 상태로 전환
                return true;
            }
        }
    }
    public void Select(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.AddItem(item);
    }
}
