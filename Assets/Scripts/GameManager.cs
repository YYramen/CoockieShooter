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
    [Tooltip("現在照準で狙われている敵")] EnemyController _currentTarget;
    [Header("スコア(コイン関係)")]
    [SerializeField, Tooltip("コイン数を表示させるテキスト")] Text _coinText;
    [Tooltip("所持している総コイン数")] long _coin = 0;
    [Header("照準関係")]
    [SerializeField, Tooltip("照準のUI")] Image _crosshairImage;
    [SerializeField, Tooltip("銃のオブジェクト")] GameObject _gunObject;
    [SerializeField, Tooltip("銃から飛ばされるRayの距離")] float _rayRange = 100f;
    [Header("ゲームスタート時に呼ばれる")]
    [SerializeField, Tooltip("ゲームスタート時に呼び出す処理")] UnityEngine.Events.UnityEvent _onGameStart = null;

    public void StartGame() //ゲームプレイを初期化する
    {
        Cursor.visible = !_hideSystemMouseCursor;
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        // 照準の処理
        _crosshairImage.rectTransform.position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //// 照準に敵がいるかどうかを調べる
        //bool isEnemyTargeted = Physics.Raycast(ray, out hit, _rayRange, _enemyLayer);
        //_currentTarget = isEnemyTargeted ? hit.collider.gameObject.GetComponent<EnemyController>() : null;

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

        // 左クリック(射撃)をした時に何に当たったかで処理を変える
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("AltFire"))
        {
            Shot();
        }
    }

    void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            Debug.Log($"{hit}に当たった");
            AddCoin(hit.collider.gameObject.GetComponent<EnemyController>().Hit());
        }
        else
        {
            Debug.Log("何にも当たらなかった");
        }
    }


    /// <summary>
    /// コインが増えるときに呼ばれる関数、取得したコインをTextに表示する
    /// </summary>
    /// <param name="coin"></param>
    void AddCoin(long coin)  //敵を倒した時、ダメージを与えたときにコインをプレイヤーに与える
    {
        _coin += coin;
        _coinText.text = _coin.ToString();

    }

    private void OnApplicationQuit()
    {

    }
}
