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

    int _itemnum = 0;
    Button _button;
    ItemTable _item;


    public void SetUp()
    {

    }
}
