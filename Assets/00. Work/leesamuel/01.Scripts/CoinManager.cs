using JetBrains.Annotations;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int Choose_Number = 0;
    private int Max_Select = 3;
    private string Selct_A = null;
    private string Selct_B = null;
    private string Selct_C = null;
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
    public void Select(InventoryItemSO item)
    {
        GameManager.instance.inventoryManager.AddItem(item);
    }
}
