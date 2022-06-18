using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 購入した Item を表示するコンポーネント
/// </summary>
public class Item : MonoBehaviour
{
    [SerializeField] Text _itemName = default;
    [SerializeField] Text _itemNum = default;


    public void SetItem(string name, int num)
    {
        _itemName.text = name;
        _itemNum.text = num.ToString();
    }

    public void UpdateNum(int num)
    {
        _itemNum.text = num.ToString();
    }
}
