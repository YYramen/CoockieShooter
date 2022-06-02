using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Player �̃R�C�����Ǘ�����
/// </summary>
public class CoinManager : SingletonMonoBehaviour<CoinManager>
{
    [Header("���ݏ������Ă���R�C���̐�"), SerializeField]  long _currentCoins = 0;
    [SerializeField, Tooltip("�R�C������\��������e�L�X�g")] Text _coinText;

    /// <summary>
    /// �R�C����������Ƃ��ɌĂ΂��֐��A�擾�����R�C����Text�ɕ\������
    /// </summary>
    /// <param name="coin"></param>
    public void AddCoin(long coin)  //�G��|�������A�_���[�W��^�����Ƃ��ɃR�C�����v���C���[�ɗ^����
    {
        _currentCoins += coin;
        _coinText.text = _currentCoins.ToString();
    }
}
