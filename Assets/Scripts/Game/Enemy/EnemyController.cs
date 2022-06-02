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
    [SerializeField, Tooltip("敵のHP")] int _enemyHp = 100;
    [SerializeField, Tooltip("敵のHPのテキスト")] Text _enemyHpText;

    [Header("コイン関係")]
    [SerializeField, Tooltip("敵を攻撃した際に貰えるコイン")] long _coinByAttacked = 1;
    [SerializeField, Tooltip("敵を倒した際に貰えるコイン")] long _coinByDeath = 100;

    [Tooltip("攻撃判定のためのコライダー")] Collider _collider = null;

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
            CoinManager.Instance.AddCoin(_coinByAttacked);
        }
        else
        {
            Debug.Log($"敵を倒した、{_coinByDeath}コインゲット");
            CoinManager.Instance.AddCoin(_coinByDeath);
            Destroy(this.gameObject);
        }
    }
}
