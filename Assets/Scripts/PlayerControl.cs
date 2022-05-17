using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動きを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
}
