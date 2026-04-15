using UnityEngine;

public class RedCoin_Control : MonoBehaviour
{
    [SerializeField] private InventoryItemSO so;

    private float _Size_Change_Scale = 0.01f;//크기 변환 속도
    private bool _Select = false;//선택되지 않음으로 시작
    [SerializeField]private float _maxSize=1.2f;
    private CoinManager CoinManager;
    bool _stopMakeBigger = false;
    private void Start()
    {

        CoinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();//메소드 불러올 준비
    }
    private void Update()
    {
        if (_Select == true)//선택되면 크기 키워서 고정
        {
            transform.localScale = new Vector3(_maxSize, _maxSize, 0);
        }
    }
    private void OnMouseOver()
    {
        if (transform.localScale.x < _maxSize && _stopMakeBigger == false)// 최소크기,최대 크기
        {
            transform.localScale += new Vector3(_Size_Change_Scale, _Size_Change_Scale, 0);
        }
    }
    private void OnMouseExit()
    {
        if (_Select == false)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
    private void OnMouseDown()
    {
        if (_Select == true)
        {
            _Select = false;
            CoinManager.Cansle_Select(so);
            //선택한 코인갯수 줄이는 메서드 작동
            _stopMakeBigger = true;
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            bool A = CoinManager.Coin_Select(so);
            if (A == false)
            {
                //나아아아중에 UI로 선택 최대치입니다 띄우기.
            }
            else
            {
                _Select = true;//선택된 상태로 전환
            }
        }
    }
}
