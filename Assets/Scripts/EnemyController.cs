using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の動きを制御するコンポーネント
/// </summary>
public class EnemyController : MonoBehaviour
{
    [Header("敵のステータス")]
    [SerializeField, Tooltip("敵のHP")] long _enemyHp = 100;
    [Header("コイン関係")]
    [SerializeField, Tooltip("敵を攻撃した際に貰えるコイン")] long _coinByAttacked = 1;
    [SerializeField, Tooltip("敵を倒した際に貰えるコイン")] long _coinByDeath = 100;

    [Tooltip("攻撃判定のためのコライダー")] Collider _collider = null;
    void Start()
    {

    }


    void Update()
    {

    }


    /// <summary>
    /// プレイヤーの攻撃が当たった時に呼ばれる関数
    /// </summary>
    /// <returns></returns>
    public long Hit()
    {
        if (_enemyHp > 0)
        {
            Debug.Log($"ダメージを与えた、{_coinByAttacked}コインゲット");
            return _coinByAttacked;
        }
        else if (_enemyHp < 0)
        {
            Debug.Log($"敵を倒した、{_coinByDeath}コインゲット");
            return _coinByDeath;
        }
        else
        {
            Debug.LogWarning("Enemy の体力が不正な値になっています、このメッセージが出た場合要修正");
            return _coinByAttacked;
        }
    }
}
