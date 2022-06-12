using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Shopウィンドウを表示したときにItemを表示するクラス。
/// </summary>
public class Shop : MonoBehaviour
{
    [SerializeField] RectTransform _itemSpace = default;
    [SerializeField] GameObject _itemPrefab = default;

    public void Start()
    {
        GameData.ItemTable.ForEach(item =>
        {
            var go = Instantiate(_itemPrefab, _itemSpace);

            go.GetComponent<ShopItem>().SetUp(item);
        });
    }
}
