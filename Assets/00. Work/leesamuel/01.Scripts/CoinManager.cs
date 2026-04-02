using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int Choose_Number = 0;
    private int Max_Select = 3;
    private string Selct_A = "NULL";
    private string Selct_B = "NULL";
    private string Selct_C = "NULL";
    public bool Select(string CoinName)//선택한양이 최대 선택량과 같으면false반환 선택한양이 최대 선택량과 다르면true반환
    {
        if(Choose_Number == Max_Select)
        {
            return false;
        }
        else
        {
            Choose_Number++;
            if (Selct_A == "NULL")
            {
                Selct_A = CoinName;
            }
            else if (Selct_B == "NULL")
            {
                Selct_B = CoinName;
            }
            else if(Selct_C == "NULL")
            {
                Selct_C = CoinName;
            }
            return true;
            
        }    
    }

    public void Cansle_Select(string CoinName)//선택 취소시선택한 양을 줄임
    {
        Choose_Number--;
        if (Selct_A == CoinName)
        {
            Selct_A = "NULL";
        }
        else if (Selct_B == CoinName)
        {
            Selct_B = "NULL";
        }
        else if (Selct_C == CoinName)
        {
            Selct_C = "NULL";
        }
    }
}
