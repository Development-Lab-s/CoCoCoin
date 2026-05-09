using UnityEngine;
using DG.Tweening;

public class ShopItem : MonoBehaviour
{
    private InventoryToolTip _inventoryToolTip;
    Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Init()
    {

    }
    private void Start()
    {
        DOTween.Init();
    }
    public void OnHover()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.1f, 0.1f));
        _animator.SetBool("Hover", true);

    }
    public void OnExit()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1f, 0.1f));
        _animator.SetBool("Hover", false);
    }
}
