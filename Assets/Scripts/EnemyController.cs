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
}
