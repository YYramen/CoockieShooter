using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 敵の動きを制御するクラス
/// </summary>
public class EnemyController : MonoBehaviour
{
    [Header("敵のステータス")]
    [SerializeField, Tooltip("敵のHP")] int _enemyHp = 10;
    [SerializeField, Tooltip("現在の敵のHPの最大値")] int _enemyMaxHp = 10;
    [SerializeField, Tooltip("敵のHPのテキスト")] Text _enemyHpText;
    [SerializeField, Tooltip("敵の現在のレベル")] int _enemyLevel = 1;
    [SerializeField, Tooltip("敵のレベルのテキスト")] Text _enemyLvText;

    [Header("コイン関係")]
    [SerializeField, Tooltip("敵を攻撃した際に貰えるコイン")] long _coinByAttacked = 1;
    [SerializeField, Tooltip("敵を倒した際に貰えるコイン")] long _coinByDeath = 10;

    [Tooltip("攻撃判定のためのコライダー")] Collider _collider = null;

    [Header("レベル関係")]
    [SerializeField, Tooltip("上がるレベル")] int _upLevel = 1;
    [SerializeField, Tooltip("上がるHPの最大値")] int _upMaxHp = 20;

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
    /// プレイヤーの攻撃が当たった時に呼ばれる関数
    /// </summary>
    /// <returns></returns>
    public void Hit(int damage)
    {
        _enemyHp -= damage;
        _enemyHpText.text = _enemyHp.ToString();
        if (_enemyHp > 0)
        {
            Debug.Log($"ダメージを与えた、{_coinByAttacked}コインゲット");
            GameManager.Instance.AddCoin(_coinByAttacked);
        }
        else if (_enemyHp <= 0)
        {
            Debug.Log($"敵を倒した、{_coinByDeath}コインゲット");
            GameManager.Instance.AddCoin(_coinByDeath);
            Respawn();
        }
        else
        {
            Debug.LogWarning("なんかおかしいよ");
        }
    }


    /// <summary>
    /// 敵が倒されたときに呼ばれる関数。敵のレベルが上がりHPの最大値も上がる。
    /// </summary>
    public void Respawn()
    {
        _enemyMaxHp += _upMaxHp;
        _enemyHp = _enemyMaxHp;
        _enemyLevel += _upLevel;

        _coinByAttacked += _coinByAttacked;
        _coinByDeath += _coinByDeath;

        Debug.Log($"敵がレベルアップ。レベルが{_upLevel}上昇。HPが{_upMaxHp}上昇、");
    }
}
