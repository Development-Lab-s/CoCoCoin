using UnityEngine;

public class Select : MonoBehaviour
{
    private CoinManager CoinManager;
    private void Start()
    {
        CoinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }
    private void OnMouseDown()
    {
        
    }
}
