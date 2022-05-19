using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �G�̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class EnemyController : MonoBehaviour
{
    [Header("�G�̃X�e�[�^�X")]
    [SerializeField, Tooltip("�G��HP")] long _enemyHp = 100;
    [SerializeField, Tooltip("�G��HP�̃e�L�X�g")] Text _enemyHpText;
    [Header("�R�C���֌W")]
    [SerializeField, Tooltip("�G���U�������ۂɖႦ��R�C��")] long _coinByAttacked = 1;
    [SerializeField, Tooltip("�G��|�����ۂɖႦ��R�C��")] long _coinByDeath = 100;

    [Tooltip("�U������̂��߂̃R���C�_�[")] Collider _collider = null;
    void Start()
    {

    }

    /// <summary>
    /// �v���C���[�̍U���������������ɌĂ΂��֐�
    /// </summary>
    /// <returns></returns>
    public long Hit()
    {
        if (_enemyHp > 0)
        {
            Debug.Log($"�_���[�W��^�����A{_coinByAttacked}�R�C���Q�b�g");
            return _coinByAttacked;
        }
        else if (_enemyHp < 0)
        {
            Debug.Log($"�G��|�����A{_coinByDeath}�R�C���Q�b�g");
            return _coinByDeath;
        }
        else
        {
            Debug.LogWarning("Enemy �̗̑͂��s���Ȓl�ɂȂ��Ă��܂��A���̃��b�Z�[�W���o���ꍇ�v�C��");
            return _coinByAttacked;
        }
    }
}
