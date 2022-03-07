using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動きを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    //プレイヤーの動き
    [SerializeField] float _movePower = 3f;
    [SerializeField] float _jumpPower = 3f;
    int _jumpCount = 0;
    int _maxJump = 1;

    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 入力を受け付けて動かす
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");


    }
}
