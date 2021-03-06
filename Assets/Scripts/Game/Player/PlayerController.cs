using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの動きを制御するクラス(銃とか照準とか)
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("攻撃力")] int _atk = 1;
    [SerializeField, Tooltip("攻撃間隔")] float _interval = 1.5f;
    public float Interval => _interval;
    float _timer = 1.5f;

    [Header("照準関係")]
    [SerializeField, Tooltip("銃のオブジェクト")] GameObject _gunObject;

    //[Header("現在装備中の武器")]
    //[Tooltip("銃の配列"), SerializeField] Base[] _guns;
    //[Tooltip("現在装備中の武器")] GunBase _currentWepon = default;

    GameManager _coinManager;

    /// <summary>
    /// ゲームスタート時に呼ばれる
    /// </summary>
    void StartGame()
    {
        _coinManager = GameManager.Instance;

        GameManager.Instance.SetPlayerController(this);
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        Crosshair();
    }

    void Crosshair()
    {
        // 照準の処理
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 銃の向く方向を変える
        _gunObject.transform.rotation = Quaternion.LookRotation(ray.direction);

        // 左クリック(Shot)をした時
        if (Input.GetButton("Fire1") && _interval < _timer)
        {
            Shot();
        }
    }

    private void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            EnemyController ec = hit.collider.GetComponent<EnemyController>();
            if (ec)
            {
                ec.Hit(_atk);
            }
            Debug.Log($"{this}が{hit}に当たった");
        }

        else
        {
            Debug.Log("何にも当たらなかった");
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);

        _timer = 0f;
    }

    public void ChangeAttack(int value)
    {
        _atk += value;
        Debug.Log($"現在の攻撃力は{_atk}");
    }

    public void PowerUp(int value)
    {
        _atk *= value;
        Debug.Log($"現在の攻撃力は{_atk}");
    }

    public void ChangeInterval(float value)
    {
        _interval -= value;
        if (_interval < 0.2f)
        {
            _interval = 0.2f;
            return;
        }
    }
}
