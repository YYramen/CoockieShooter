using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの動きを制御するクラス(銃とか照準とか)
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("マウスカーソルをゲーム中に消すかどうかの設定")]
    [SerializeField] public bool _hideSystemMouseCursor = false;

    [Header("照準関係")]
    [SerializeField, Tooltip("照準のUI")] Image _crosshairImage;
    [SerializeField, Tooltip("銃のオブジェクト")] GameObject _gunObject;
    [SerializeField, Tooltip("銃から飛ばされるRayの距離")] float _rayRange = 100f;

    [Header("現在装備中の武器")]
    [Tooltip("銃の配列"), SerializeField] GunBase[] _guns;
    [Tooltip("現在装備中の武器")] GunBase _currentWepon = default;

    GameManager _coinManager;

    /// <summary>
    /// ゲームスタート時に呼ばれる
    /// </summary>
    void StartGame()
    {
        _coinManager = GameManager.Instance;

        Cursor.visible = _hideSystemMouseCursor;

        _currentWepon = _guns[0];
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        Crosshair();
    }

    void Crosshair()
    {
        // 照準の処理
        _crosshairImage.rectTransform.position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        // 銃の向く方向を変える
        _gunObject.transform.rotation = Quaternion.LookRotation(ray.direction);

        // 左クリック(Shot)をした時
        if (Input.GetButtonDown("Fire1"))
        {
            _currentWepon.Shot();
        }

        //右クリック(AltShot)をした時
        if (Input.GetButtonDown("Fire2"))
        {
            _currentWepon.AltShot();
        }
    }
}
