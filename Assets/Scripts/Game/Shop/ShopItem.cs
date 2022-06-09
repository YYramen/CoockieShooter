using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ショップのアイテム(ボタンにアタッチして使う)を設定するクラス。
/// </summary>
public class ShopItem : MonoBehaviour
{
    [Tooltip("アイテムの名前") , SerializeField] Text _name;
    [Tooltip("アイテムのコスト"), SerializeField] Text _value;
    [Tooltip("アイテムを持っている個数"), SerializeField] Text _num;
    int _itemNum = 0;
    Button _itemBtn;
    Button _button;
    ItemTable _item;


    public void SetUp(ItemTable item)
    {
        _item = item;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            if (Value() > CoinManager._currentCoins) return;

        });
        
    }

    int Value()
    {
        return Mathf.FloorToInt(_item.value * (1f + (float)(_itemNum / 10f)));
    }

    public void UpdateItem()
    {
        _name.text = _item.Name;

        if (_item.Type == ItemType.Wepon)
        {
            _itemNum = CoinManager.Wepon.GetLevel(_item.targetId);
        }
    }
}
