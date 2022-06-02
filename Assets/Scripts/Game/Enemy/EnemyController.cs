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
    [SerializeField, Tooltip("�G��HP")] int _enemyHp = 100;
    [SerializeField, Tooltip("�G��HP�̃e�L�X�g")] Text _enemyHpText;

    [Header("�R�C���֌W")]
    [SerializeField, Tooltip("�G���U�������ۂɖႦ��R�C��")] long _coinByAttacked = 1;
    [SerializeField, Tooltip("�G��|�����ۂɖႦ��R�C��")] long _coinByDeath = 100;

    [Tooltip("�U������̂��߂̃R���C�_�[")] Collider _collider = null;

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
            CoinManager.Instance.AddCoin(_coinByAttacked);
        }
        else
        {
            Debug.Log($"�G��|�����A{_coinByDeath}�R�C���Q�b�g");
            CoinManager.Instance.AddCoin(_coinByDeath);
            Destroy(this.gameObject);
        }
    }
}
