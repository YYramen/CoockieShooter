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

    int _itemnum = 0;
    Button _button;
    ItemTable _item;


    public void SetUp()
    {

    }
}
