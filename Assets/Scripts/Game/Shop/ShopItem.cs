using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// �V���b�v�̃A�C�e��(�{�^���ɃA�^�b�`���Ďg��)��ݒ肷��N���X�B
/// </summary>
public class ShopItem : MonoBehaviour
{
    [Tooltip("�A�C�e���̖��O") , SerializeField] Text _name;
    [Tooltip("�A�C�e���̃R�X�g"), SerializeField] Text _value;
    [Tooltip("�A�C�e���������Ă����"), SerializeField] Text _num;
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
