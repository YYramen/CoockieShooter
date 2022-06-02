using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// �Q�[�����Ǘ�����X�N���v�g�A�K���ȃI�u�W�F�N�g�ɃA�^�b�`���Đݒ肷��Γ���
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //[Header("�}�E�X�J�[�\�����Q�[�����ɏ������ǂ����̐ݒ�")]
    //[SerializeField] bool _hideSystemMouseCursor = false;

    [Header("�G�֘A")]
    [SerializeField, Tooltip("�G�����郌�C���[")] LayerMask _enemyLayer = default;
    [Tooltip("���ݏƏ��ő_���Ă���G")] EnemyController _currentTarget;

    [Header("�X�R�A(�R�C���֌W)")]
    [SerializeField, Tooltip("�R�C������\��������e�L�X�g")] Text _coinText;
    [Tooltip("�������Ă��鑍�R�C����")] [SerializeField] long _coin = 0;

    [Header("�Q�[���X�^�[�g���ɌĂ΂��")]
    [SerializeField, Tooltip("�Q�[���X�^�[�g���ɌĂяo������")] UnityEngine.Events.UnityEvent _onGameStart = null;

    

    void Start()
    {
        
    }

    /// <summary>
    /// �R�C����������Ƃ��ɌĂ΂��֐��A�擾�����R�C����Text�ɕ\������
    /// </summary>
    /// <param name="coin"></param>
    public void AddCoin(long coin)  //�G��|�������A�_���[�W��^�����Ƃ��ɃR�C�����v���C���[�ɗ^����
    {
        _coin += coin;
        _coinText.text = _coin.ToString();
    }

    private void OnApplicationQuit()
    {

    }
}
