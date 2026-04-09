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
        if (coinManager.select_a != null)
            coinManager.Select(coinManager.select_a);
        if(coinManager.select_b != null)
            coinManager.Select(coinManager.select_b);
        if(coinManager.select_c != null)
            coinManager.Select(coinManager.select_c);
    }
}
