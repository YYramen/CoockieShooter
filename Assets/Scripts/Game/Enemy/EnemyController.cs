using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �G�̓����𐧌䂷��N���X
/// </summary>
public class EnemyController : MonoBehaviour
{
    [Header("�G�̃X�e�[�^�X")]
    [SerializeField, Tooltip("�G��HP")] int _enemyHp = 10;
    [SerializeField, Tooltip("���݂̓G��HP�̍ő�l")] int _enemyMaxHp = 10;
    [SerializeField, Tooltip("�G��HP�̃e�L�X�g")] Text _enemyHpText;
    [SerializeField, Tooltip("�G�̌��݂̃��x��")] int _enemyLevel = 1;
    [SerializeField, Tooltip("�G�̃��x���̃e�L�X�g")] Text _enemyLvText;

    [Header("�R�C���֌W")]
    [SerializeField, Tooltip("�G���U�������ۂɖႦ��R�C��")] long _coinByAttacked = 1;
    [SerializeField, Tooltip("�G��|�����ۂɖႦ��R�C��")] long _coinByDeath = 10;

    [Tooltip("�U������̂��߂̃R���C�_�[")] Collider _collider = null;

    [Header("���x���֌W")]
    [SerializeField, Tooltip("�オ�郌�x��")] int _upLevel = 1;
    [SerializeField, Tooltip("�オ��HP�̍ő�l")] int _upMaxHp = 20;

    private void Start()
    {
        _enemyHp = _enemyMaxHp;
    }

    private void Update()
    { 
        _enemyHpText.text = _enemyHp.ToString();
        _enemyLvText.text = _enemyLevel.ToString();

    }

    /// <summary>
    /// �v���C���[�̍U���������������ɌĂ΂��֐�
    /// </summary>
    /// <returns></returns>
    public void Hit(int damage)
    {
        _enemyHp -= damage;
        _enemyHpText.text = _enemyHp.ToString();
        if (_enemyHp > 0)
        {
            Debug.Log($"�_���[�W��^�����A{_coinByAttacked}�R�C���Q�b�g");
            GameManager.Instance.AddCoin(_coinByAttacked);
        }
        else if (_enemyHp <= 0)
        {
            Debug.Log($"�G��|�����A{_coinByDeath}�R�C���Q�b�g");
            GameManager.Instance.AddCoin(_coinByDeath);
            Respawn();
        }
        else
        {
            Debug.LogWarning("�Ȃ񂩂���������");
        }
    }


    /// <summary>
    /// �G���|���ꂽ�Ƃ��ɌĂ΂��֐��B�G�̃��x�����オ��HP�̍ő�l���オ��B
    /// </summary>
    public void Respawn()
    {
        _enemyMaxHp += _upMaxHp;
        _enemyHp = _enemyMaxHp;
        _enemyLevel += _upLevel;

        _coinByAttacked += _coinByAttacked;
        _coinByDeath += _coinByDeath;

        Debug.Log($"�G�����x���A�b�v�B���x����{_upLevel}�㏸�BHP��{_upMaxHp}�㏸�A");
    }
}
