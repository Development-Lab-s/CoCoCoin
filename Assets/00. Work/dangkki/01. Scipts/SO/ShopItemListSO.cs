using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemListSO", menuName = "Scriptable Objects/ShopItemListSO")]
public class ShopItemListSO : ScriptableObject
{
    public List<ShopItemSO> ShopItemList;
}
