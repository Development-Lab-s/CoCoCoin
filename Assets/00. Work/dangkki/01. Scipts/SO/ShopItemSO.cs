using UnityEngine;


[CreateAssetMenu(fileName = "ShopItemSO", menuName = "Scriptable Objects/ShopItemSO")]
public class ShopItemSO : InventoryItemSO
{
    public new enum Rarity
    {
        Common,
        Rare,
        Legendary
    }
    public AnimationClip SpinSprite;
    public AnimatorOverrideController SelectSprite;
    public Rarity ItemRarity;
}
