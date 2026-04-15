using UnityEngine;

public class Select : MonoBehaviour
{
    private CoinManager coinManager;
    private void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }
    private void OnMouseDown()//셀렉트누르면 인벤토리에 넣어줌
    {
        if (coinManager.select_a != null&& coinManager.select_b != null&& coinManager.select_c != null)//3개 모두 선택돼야만 작동
        {
            coinManager.Select(coinManager.select_a);

            coinManager.Select(coinManager.select_b);

            coinManager.Select(coinManager.select_c);
        }
            
    }
}
