using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// �w������ Item ��\������R���|�[�l���g
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
}
