using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの動きを制御するコンポーネント(銃とか照準とか)
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("マウスカーソルをゲーム中に消すかどうかの設定")]
    [SerializeField] bool _hideSystemMouseCursor = false;

    [Header("照準関係")]
    [SerializeField, Tooltip("照準のUI")] Image _crosshairImage;
    [SerializeField, Tooltip("銃のオブジェクト")] GameObject _gunObject;
    [SerializeField, Tooltip("銃から飛ばされるRayの距離")] float _rayRange = 100f;

    [Header("現在装備中の武器")]
    [SerializeField, Tooltip("現在装備中の武器")] GameObject _currentWepon = default;

    /// <summary>
    /// ゲームスタート時に呼ばれる
    /// </summary>
    void StartGame()
    {
        Cursor.visible = _hideSystemMouseCursor;

        if (_hideSystemMouseCursor)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        
    }

    void Crosshair()
    {
        // 照準の処理
        _crosshairImage.rectTransform.position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // 銃の向く方向を変える
        _gunObject.transform.rotation = Quaternion.LookRotation(ray.direction);

        if (Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Gun")))
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        // 左クリック(Shot)をした時
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }

        //右クリック(AltShot)をした時
        if (Input.GetButtonDown("Fire2"))
        {
            //AltShot();
        }
    }
}
