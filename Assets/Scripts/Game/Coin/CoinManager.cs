using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Player �̃R�C�����Ǘ�����N���X�B�Ǘ����Ă��镨���R�C���Ȃ̂ł��̂���GameManager�ɂȂ肻���B
/// </summary>
public class CoinManager : SingletonMonoBehaviour<CoinManager>
{
    [Header("���ݏ������Ă���R�C���̐�"), SerializeField] static public long _currentCoins = 0;
    [SerializeField, Tooltip("�R�C������\��������e�L�X�g")] Text _coinText;
    WeponManager _weponManager;
    public static WeponManager Wepon => CoinManager.Instance._weponManager;


    /// <summary>
    /// �R�C����������Ƃ��ɌĂ΂��֐��A�擾�����R�C����Text�ɕ\������
    /// </summary>
    /// <param name="coin"></param>
    public void AddCoin(long coin)  //�G��|�������A�_���[�W��^�����Ƃ��ɃR�C�����v���C���[�ɗ^����
    {
       _currentCoins += coin;
        _coinText.text = _currentCoins.ToString();
    }

    /// <summary>
    /// �A�C�e�����w�����鏈��
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cost"></param>
    static public void Buy(ItemTable item, int cost)
    {
        _currentCoins -= cost;
        switch (item.Type)
        {
            //case ItemType.Wepon:  //TODO �A�C�e���𔃂����������B

        }
    }
}
