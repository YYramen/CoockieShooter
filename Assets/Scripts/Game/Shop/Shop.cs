using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Shop�E�B���h�E��\�������Ƃ���Item��\������N���X�B
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
