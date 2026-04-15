using UnityEngine;

public class RedCoin_Control : MonoBehaviour
{
    [SerializeField] private InventoryItemSO so;

    private float _Size_Change_Scale = 0.01f;//크기 변환 속도
    private bool _Select = false;//선택되지 않음으로 시작
    [SerializeField]private float _maxSize=1.2f;
    private CoinManager CoinManager;
    bool _MakeBigger = true;
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
        if (transform.localScale.x < _maxSize && _MakeBigger == true)// 최소크기,최대 크기
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
        _MakeBigger = true;
    }
    private void OnMouseDown()
    {
        _MakeBigger=_Select=CoinManager.SelectCodeinCoin(_Select, so);
        if (_Select == false)
        {
            transform.localScale = new Vector3(1, 1, 0);//취소시 벡터 리셋
        }
    }
}
