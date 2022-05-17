using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ゲームを管理するスクリプト、適当なオブジェクトにアタッチして設定すれば動く
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("マウスカーソルをゲーム中に消すかどうかの設定")]
    [SerializeField] bool _hideSystemMouseCursor = false;
    [Header("敵関連")]
    [SerializeField, Tooltip("敵がいるレイヤー")] LayerMask _enemyLayer = default;
    /// <summary>現在照準で狙われている敵</summary>
    [Tooltip("現在照準で狙われている敵")] EnemyController _currentTarget;
    [Header("照準関係")]
    [SerializeField, Tooltip("照準のUI")] Image _crosshairImage;
    [SerializeField, Tooltip("銃のオブジェクト")] GameObject _gunObject;
    [SerializeField, Tooltip("銃から飛ばされるRayの距離")] float _rayRange = 100f;
    [Header("ゲームスタート時に呼ばれる")]
    [SerializeField, Tooltip("ゲームスタート時に呼び出す処理")] UnityEngine.Events.UnityEvent _onGameStart = null;

    public void StartGame() //ゲームプレイを初期化する
    {
        if (_hideSystemMouseCursor)
        {
            Cursor.visible = false;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        // 照準の処理
        _crosshairImage.rectTransform.position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        _gunObject.transform.rotation = Quaternion.LookRotation(ray.direction);     //// 銃の向く方向を変えている

        if (Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Gun")))
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        //if (Physics.Raycast(ray, out hit, _rayRange))
        //{
        //    _gunObject.transform.LookAt(hit.point);    // 銃の方向を変えている(一旦これなし)
        //}

        // 敵が照準に入っているか調べる
        bool isEnemyTargeted = Physics.Raycast(ray, out hit, _rayRange, _enemyLayer);
        _currentTarget = isEnemyTargeted ? hit.collider.gameObject.GetComponent<EnemyController>() : null;    // 三項演算子 ? を使っている
    }

    void AddCoin()  //敵を倒した時、ダメージを与えたときにコインをプレイヤーに与える
    {

    }

    private void OnApplicationQuit()
    {

    }
}
