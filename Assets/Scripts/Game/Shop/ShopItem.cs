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
    Button _button;
    ItemTable _item;

    public void SetUp(ItemTable item)
    {
        _item = item;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            if (Value() > GameManager.Instance.Currentcoins) return;
            UpdateItem();
            GameManager.Instance.Buy(_item,Value());
        });
        UpdateItem();
    }

    int Value()
    {
        return Mathf.FloorToInt(_item.price * (1f + (float)(_itemNum / 10f)));
    }

    public void UpdateItem()
    {
        _name.text = _item.Name;

        if (_item.Type == ItemType.Wepon)
        {
            _itemNum = GameManager.Instance.Wepon.GetLevel(_item.targetId);
            _num.text = _itemNum.ToString();
        }
        else
        {
            _num.text = "0";
        }
        _value.text = string.Format("Price:{0}", ValueConverter.Convert(Value()));
    }

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        if (GameManager.Instance.Currentcoins < Value())
        {
            _value.color = Color.gray;
        }
        else
        {
            _value.color = Color.black;
        }
    }
}
